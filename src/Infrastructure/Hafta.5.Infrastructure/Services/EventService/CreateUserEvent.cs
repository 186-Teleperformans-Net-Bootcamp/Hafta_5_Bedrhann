using Hafta._5.Application.Interfaces.EventServices;
using RabbitMQ.Client;
using System.Text;

namespace Hafta._5.Infrastructure.Services.EventService
{
    public class CreateUserEvent : ICreateUserEvent
    {
        public void SendEvent(string Username)
        {

            var connectionFactory = new ConnectionFactory()//Bağlantı ayarlarını yapıyoruz.
            {
                HostName = "localhost",
                VirtualHost = "/",
                Port = 5672,
                UserName = "bedirhan",
                Password = "abc1234"
            };
            using var connection = connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.ExchangeDeclare("fanout.test", "fanout", false, false);
            channel.QueueDeclare("fanout.UserCreatQue", false, false, true);
            channel.QueueBind("fanout.UserCreatQue", "fanout.test", string.Empty);

            //Kuyruğa göndereceğimiz bilgileri giriyoruz.
            channel.BasicPublish("fanout.test", string.Empty, null, Encoding.UTF8.GetBytes("Yeni Kullanıcı Eklendi. => " + Username));


            channel.Close();
            connection.Close();


        }
    }
}
