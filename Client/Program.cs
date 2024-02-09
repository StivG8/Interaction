using RabbitMQ;
using System.Text;

namespace Client
{
    static class Program
    {
        private static readonly string queueName = "SampleQueue";

        static void Main(string[] args)
        {
            Console.WriteLine("CLIENT");

            var rmq = new RabbitMqService();
            rmq.RegisterListener(queueName, onReceive: (sender, arg) =>
            {
                var message = Encoding.UTF8.GetString(arg.Body.ToArray());
                Console.Write($"Data: {message}... ");
                Thread.Sleep(1000);
                Console.WriteLine($"done");
            });

            while (true)
            {
                Console.WriteLine("Enter text (\"exit\" for stop): ");
                var s = Console.ReadLine();
                if (s == "exit") break;
            }
        }
    }
}