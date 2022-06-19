using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace UserBackgroundService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var connectionFactory = new ConnectionFactory()
                {
                    HostName = "localhost",
                    VirtualHost = "/",
                    Port = 5672,
                    UserName = "bedirhan",
                    Password = "abc1234"
                };

                var connection = connectionFactory.CreateConnection();
                var channel = connection.CreateModel();
                channel.QueueDeclare("direct.UserCreatQue", false, false, true);
                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (sender, args) =>
                {
                    var message = Encoding.UTF8.GetString(args.Body.ToArray());
                    File.AppendAllText(@"E:\DotNetWork\UserRegistration.txt", message + " Date:" + DateTime.Now.ToString() + "\n");
                };
                channel.BasicConsume("fanout.UserCreatQue", false, consumer);
            }
        }
    }
}