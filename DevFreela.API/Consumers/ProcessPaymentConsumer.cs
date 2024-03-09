
using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Core.DTOs;
using DevFreela.Core.Services;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace DevFreela.API.Consumers
{
    public class ProcessPaymentConsumer : BackgroundService
    {
        private const string QUEUE = "Payments";
        private const string PAYMENT_APROVED_QUEUE = "PaymentApproved";
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public ProcessPaymentConsumer(IConnection connection)
        {
            _connection = connection;

            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = factory.CreateConnection();
            _channel = connection.CreateModel();

            _channel.QueueDeclare(
                queue: QUEUE,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
                );

            _channel.QueueDeclare(
                queue: PAYMENT_APROVED_QUEUE,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
                );

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender,eventsArgs) =>
            {
                var byteArray = eventsArgs.Body.ToArray();
                var paymentInfoJson = Encoding.UTF8.GetString(byteArray);

                var paymentInfo = JsonSerializer.Deserialize<PaymentInfoInputModel>(paymentInfoJson);
                
                ProcessPayment(paymentInfo);

                var paymentApproved = new PaymentApprovedIntegrationEvent(paymentInfo.IdProject);
                var paymentApprovedJson = JsonSerializer.Serialize(paymentApproved);
                var paymentApprovedBytes = Encoding.UTF8.GetBytes(paymentApprovedJson);

                _channel.BasicPublish(
                    exchange: "",
                    routingKey: PAYMENT_APROVED_QUEUE,
                    basicProperties: null,
                    body: paymentApprovedBytes
                    );

                _channel.BasicAck(eventsArgs.DeliveryTag,false);

            };

            _channel.BasicConsume(QUEUE,false,consumer);

            return Task.CompletedTask;
        }

        public void ProcessPayment(PaymentInfoInputModel paymentInfoInputModel)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var paymentService = scope.ServiceProvider.GetRequiredService<IPaymentService>();

                var paymentInfoDTO = new PaymentInfoDTO(
                    paymentInfoInputModel.IdProject,
                    paymentInfoInputModel.CreditCardNumber,
                    paymentInfoInputModel.Cvv,
                    paymentInfoInputModel.ExpiresAt,
                    paymentInfoInputModel.FullName,
                    paymentInfoInputModel.Amount
                    );

                paymentService.ProcessPayment(paymentInfoDTO);
            }
        }
    }
}
