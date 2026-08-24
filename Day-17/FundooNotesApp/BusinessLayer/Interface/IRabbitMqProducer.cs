namespace BusinessLayer.Interface;

/// <summary>
/// Day-17: RabbitMQ Producer interface.
/// Publishes messages to a RabbitMQ queue for asynchronous processing.
/// </summary>
public interface IRabbitMqProducer
{
    /// <summary>
    /// Publishes a serialized message to the specified queue.
    /// </summary>
    Task PublishAsync<T>(string queueName, T message);
}
