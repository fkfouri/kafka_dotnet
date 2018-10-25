using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer
{
    class Program_Producer
    {
        static void Main(string[] args)
        {
            var options = new KafkaOptions   (new Uri("http://sjkap556:9092"));
            var router = new BrokerRouter(options);

            var client = new KafkaNet.Producer(router);

            for (int i = 0; i < 1; i++)
            {
                client.SendMessageAsync("testCockpit", new[] { new Message(DateTime.Now + " -- Teste: " + i) }).Wait();
            }
            Console.ReadLine();

        }
    }
}
