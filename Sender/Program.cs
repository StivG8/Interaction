using RabbitMQ;

namespace Sender
{
    static class Program
    {
        private static readonly string queueName = "SampleQueue";

        static void Main(string[] args)
        {
            Console.WriteLine("SENDER");

            var rmq = new RabbitMqService();

            while (true)
            {
                Console.Write("Enter text (\"exit\" for stop): ");
                var s = Console.ReadLine();
                if (s == "exit") break;

                rmq.Publish(queueName, s);
            }
        }
    }
}