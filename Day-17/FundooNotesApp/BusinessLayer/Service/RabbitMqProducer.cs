using System.Text;
using System.Text.Json;
using BusinessLayer.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace BusinessLayer.Service;

/// <summary>
/// Day-17: RabbitMQ Producer — publishes messages to a RabbitMQ queue.
/// Connection is created once and reused for the lifetime of the service.
/// </summary>
public class RabbitMqProducer : IRabbitMqProducer, IAsyncDisposable
{
    private readonly ILogger<RabbitMqProducer> _logger;
    private readonly ConnectionFactory _factory;
    private IConnection? _connection;
    private IChannel? _channel;
    private readonly SemaphoreSlim _initLock = new(1, 1);

    public RabbitMqProducer(IConfiguration configuration, ILogger<RabbitMqProducer> logger)
    {
        _logger = logger;

        var rabbitConfig = configuration.GetSection("RabbitMQ");
        _factory = new ConnectionFactory
        {
            HostName = rabbitConfig["HostName"] ?? "localhost",
            Port     = int.TryParse(rabbitConfig["Port"], out var port) ? port : 5672,
            UserName = rabbitConfig["UserName"] ?? "guest",
            Password = rabbitConfig["Password"] ?? "guest"
        };
    }

    /// <summary>
    /// Lazily initializes the RabbitMQ connection and channel.
    /// Thread-safe via SemaphoreSlim.
    /// </summary>
    private async Task EnsureConnectedAsync()
    {
        if (_connection is { IsOpen: true } && _channel is { IsOpen: true })
            return;

        await _initLock.WaitAsync();
        try
        {
            if (_connection is null or { IsOpen: false })
            {
                _connection = await _factory.CreateConnectionAsync();
                _logger.LogInformation("RabbitMQ connection established to {Host}:{Port}",
                    _factory.HostName, _factory.Port);
            }

            if (_channel is null or { IsOpen: false })
            {
                _channel = await _connection.CreateChannelAsync();
            }
        }
        finally
        {
            _initLock.Release();
        }
    }

    public async Task PublishAsync<T>(string queueName, T message)
    {
        try
        {
            await EnsureConnectedAsync();

            // Declare the queue (idempotent — safe to call multiple times)
            await _channel!.QueueDeclareAsync(
                queue: queueName,
                durable: true,
                exclusive: false,
                autoDelete: false);

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            await _channel.BasicPublishAsync(
                exchange: string.Empty,
                routingKey: queueName,
                body: body);

            _logger.LogInformation("Published message to queue '{Queue}': {Message}", queueName, json);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to publish message to RabbitMQ queue '{Queue}'", queueName);
            // Don't throw — the reminder is already saved in the DB.
            // RabbitMQ failure should not break the API response.
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_channel is { IsOpen: true })
            await _channel.CloseAsync();
        if (_connection is { IsOpen: true })
            await _connection.CloseAsync();

        _channel?.Dispose();
        _connection?.Dispose();
        _initLock.Dispose();

        GC.SuppressFinalize(this);
    }
}
