
using RabbitMQ.Client;
using System.Text;

Console.WriteLine("Hello, World!");

var factory = new ConnectionFactory()
{
    HostName = "goose.rmq2.cloudamqp.com",
    UserName = "lwpfmkvp",
    VirtualHost = "lwpfmkvp",
    Password = "ONy0uB8sESyinHD2hRrJ-5Q9hqnUp-4M"
};
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "student",
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

    while (true)
    {
        string message = $"Krzysztof Bogucki";
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(exchange: "",
                             routingKey: "student",
                             basicProperties: null,
                             body: body);
        Console.WriteLine(" [x] Sent {0}", message);

        System.Threading.Thread.Sleep(10000);
    }
}