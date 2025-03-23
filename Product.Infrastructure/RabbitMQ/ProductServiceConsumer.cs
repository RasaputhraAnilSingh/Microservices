using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson.IO;
using Newtonsoft.Json.Linq;
using Product.Infrastructure.Entities;
using Product.Infrastructure.Repositories.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using ZstdSharp;

namespace Product.Infrastructure.RabbitMQ
{
    public class ProductServiceConsumer : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IProductRepository _repository;
        private readonly ConnectionFactory _factory;
        private IConnection _connection;
        private IChannel _channel;
        private const string ExchangeName = "order_exchange";
        private const string RoutingKey = "order_created";
        private const string QueueName = "product_queue";

        public ProductServiceConsumer(IConfiguration configuration,IProductRepository productRepository)
        {
            _configuration = configuration;
            _repository = productRepository;
            var rabbitMQConfig = configuration.GetSection("RabbitMQ");
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

            // Declare Queue
            await _channel.QueueDeclareAsync(
                queue: QueueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            // Bind Queue to Exchange
           await _channel.QueueBindAsync(
                queue: QueueName,
                exchange: ExchangeName,
                routingKey: RoutingKey);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string _message = string.Empty;
            try
            {
                await InitializeConnectionAsync();

            }
            catch (Exception ex) { }

            var consumer = new AsyncEventingBasicConsumer(_channel);

            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                string message = Encoding.UTF8.GetString(body);
                _message = message;

                // Process the message asynchronously
                try
                {
                    await ProcessMessageAsync(_message);
                }
                catch(Exception ex) 
                {
                    await _channel.BasicNackAsync(deliveryTag: ea.DeliveryTag, multiple: false,requeue : true);

                }
                // Acknowledge message
                await _channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
            };

            
            await _channel.BasicConsumeAsync(queue: QueueName, autoAck: false, consumer: consumer);
           
            await Task.CompletedTask;
        }
        private async Task ProcessMessageAsync(string msg)
        {
            ProductEntity product = new ProductEntity();

             JObject obj = JObject.Parse(msg);
            product.Id = (int)obj["ProductId"];
            product.Quantity = (int)obj["Quantity"];

            if (product.Id == 0)
            {
                throw new Exception();
            }

            await _repository.UpdateProductById(product);
        }

    }

}
