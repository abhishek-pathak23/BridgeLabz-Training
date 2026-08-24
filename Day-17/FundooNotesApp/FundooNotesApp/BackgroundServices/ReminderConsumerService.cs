using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace FundooNotesApp.BackgroundServices;

/// <summary>
/// Day-17: RabbitMQ Consumer — runs as a BackgroundService.
/// Listens to the "reminder_queue" and processes reminder events.
/// In a real app, this would trigger email/push notifications at the scheduled time.
/// </summary>
public class ReminderConsumerService : BackgroundService
{
    private readonly ILogger<ReminderConsumerService> _logger;
    private readonly ConnectionFactory _factory;
    private const string QueueName = "reminder_queue";

    public ReminderConsumerService(IConfiguration configuration, ILogger<ReminderConsumerService> logger)
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

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("ReminderConsumerService started. Waiting for messages on queue '{Queue}'...", QueueName);

        try
        {
            using var connection = await _factory.CreateConnectionAsync(stoppingToken);
            using var channel = await connection.CreateChannelAsync(cancellationToken: stoppingToken);

            await channel.QueueDeclareAsync(
                queue: QueueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                cancellationToken: stoppingToken);

            // Prefetch 1 message at a time for fair dispatch
            await channel.BasicQosAsync(prefetchSize: 0, prefetchCount: 1, global: false, cancellationToken: stoppingToken);

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (_, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var json = Encoding.UTF8.GetString(body);

                    _logger.LogInformation(
                        "═══════════════════════════════════════════════════════════════");
                    _logger.LogInformation(
                        "📬 Reminder Event Received from RabbitMQ:");
                    _logger.LogInformation("   Payload: {Json}", json);

                    // ── Deserialize and process ──────────────────────────────────
                    var reminder = JsonSerializer.Deserialize<ReminderEvent>(json);
                    if (reminder != null)
                    {
                        _logger.LogInformation(
                            "   → NoteId: {NoteId} | User: {Email} | Reminder At: {ReminderAt}",
                            reminder.NoteId, reminder.UserEmail, reminder.ReminderAt);

                        // In production, this is where you would:
                        // 1. Check if the reminder time has arrived
                        // 2. Send an email / push notification
                        // 3. Mark the reminder as "sent" in the database
                        _logger.LogInformation(
                            "   ✅ Reminder processed successfully (notification would be sent here).");
                    }

                    _logger.LogInformation(
                        "═══════════════════════════════════════════════════════════════");

                    // Acknowledge the message
                    await channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing reminder message.");
                    // Negative ack — requeue the message for retry
                    await channel.BasicNackAsync(deliveryTag: ea.DeliveryTag, multiple: false, requeue: true);
                }
            };

            await channel.BasicConsumeAsync(
                queue: QueueName,
                autoAck: false,
                consumer: consumer,
                cancellationToken: stoppingToken);

            // Keep alive until cancellation is requested
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation("ReminderConsumerService is shutting down.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ReminderConsumerService encountered an error. " +
                                  "Ensure RabbitMQ is running at the configured host. " +
                                  "The API will continue to work without RabbitMQ.");
        }
    }
}

/// <summary>
/// Day-17: Event payload published to RabbitMQ when a reminder is set.
/// </summary>
public class ReminderEvent
{
    public int NoteId { get; set; }
    public string NoteTitle { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public DateTime? ReminderAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
