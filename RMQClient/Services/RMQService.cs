
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RMQClient.Interfaces;
using RMQClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RMQClient.Services
{
    public class RMQService : IRMQService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RMQService(RMQOptions options)
        {
            var factory = new ConnectionFactory()
            {
                HostName = options.HostName,
                UserName = options.UserName,
                Password = options.Password,
                VirtualHost = options.VirtualHost,
                Port = options.Port
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void Publish<T>(string exchange, string routingKey, T message)
        {
            _channel.ExchangeDeclare(exchange, ExchangeType.Direct, durable: true);
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            _channel.BasicPublish(exchange, routingKey, null, body);
            Console.WriteLine($"[x] Published to {exchange} | {routingKey} -> {JsonSerializer.Serialize(message)}");
        }

        public void Consume(string exchange, string queue, string routingKey, Action<string> onMessageReceived)
        {
            _channel.ExchangeDeclare(exchange, ExchangeType.Direct, durable: true);
            _channel.QueueDeclare(queue, durable: true, exclusive: false, autoDelete: false);
            _channel.QueueBind(queue, exchange, routingKey);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (_, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                onMessageReceived(message);
                _channel.BasicAck(ea.DeliveryTag, false);
            
            };

            _channel.BasicConsume(queue, autoAck: false, consumer);
            Console.WriteLine($"[*] Listening on '{queue}' for '{routingKey}'");
        }

        public void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
        }
    }
}
