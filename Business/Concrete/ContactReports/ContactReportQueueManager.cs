using Business.Constants;
using Business.Interfaces.ContactReports;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Business.Concrete.ContactReports
{
    public class ContactReportQueueManager : IContactReportQueueService
    {
        private IConnection _connection;

        public ContactReportQueueManager()
        {
            CreateConnection();
        }

        public void Send<T>(string queue, T data)
        {
            if (ConnectionExists())
            {
                using (var channel = _connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var json = JsonConvert.SerializeObject(data);
                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(exchange: "", routingKey: queue, basicProperties: null, body: body);
                }
            }
        }

        public T Receive<T>(string queue)
        {
            string data = null;
            using (IConnection connection = new ConnectionFactory().CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue, false, false, false, null);
                    var consumer = new EventingBasicConsumer(channel);
                    BasicGetResult result = channel.BasicGet(queue, true);
                    if (result != null)
                    {
                        data = Encoding.UTF8.GetString(result.Body.ToArray());
                    }
                }
            }
            return JsonConvert.DeserializeObject<T>(data);
        }

        private void CreateConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory
            {
                HostName = QueueConstants.QueueHostName,
                Port = QueueConstants.QueuePort,
                UserName = QueueConstants.QueueUserName,
                Password = QueueConstants.QueuePassword
            };
            _connection = connectionFactory.CreateConnection();
        }

        private bool ConnectionExists()
        {
            if (_connection != null)
            {
                return true;
            }

            CreateConnection();

            return _connection != null;
        }

    }
}
