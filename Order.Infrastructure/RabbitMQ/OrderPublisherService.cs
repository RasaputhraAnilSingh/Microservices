using Microsoft.Extensions.Configuration;
using Order.Infrastructure.Entities;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
namespace Order.Infrastructure.RabbitMQ
{
    public class OrderPublisherService
    {
        private readonly ConnectionFactory _factory;
        private IConnection _connection;
        private IChannel _channel;
        private readonly IConfiguration _configuration;
        private const string ExchangeName = "order_exchange";
        private const string RoutingKey = "order_created";
        public OrderPublisherService(IConfiguration configuration)
        {
            _configuration = configuration;
            var rabbitMQConfig = _configuration.GetSection("RabbitMQ");
            _factory = new ConnectionFactory()
            {

                HostName = rabbitMQConfig["HostName"],
                UserName = rabbitMQConfig["UserName"],
                Password = rabbitMQConfig["Password"]

            };
        }
        public async Task InitializeConnectionAsync()
        {
            _connection = await _factory.CreateConnectionAsync();
            _channel = await _connection.CreateChannelAsync();

            // Declare Exchange (Direct Mode)
            await _channel.ExchangeDeclareAsync(exchange: ExchangeName, type: ExchangeType.Direct, durable: true);

            // Declare Queue
            await _channel.QueueDeclareAsync(queue: "product_queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

            // Bind Queue to Exchange
            await _channel.QueueBindAsync(queue: "product_queue", exchange: ExchangeName, routingKey: RoutingKey);
        }

        public async Task PublishOrderEventAsync(OrderEntity order)
        {
            var message = JsonSerializer.Serialize(order);
            var body = Encoding.UTF8.GetBytes(message);

            var properties = new BasicProperties() { Persistent = true };

            await _channel.BasicPublishAsync(exchange: ExchangeName, routingKey: RoutingKey, mandatory: false, properties, body: body);

        }

    }
}