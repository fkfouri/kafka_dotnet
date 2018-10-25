using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    class Program_consumer
    {
        static void Main(string[] args)
        {
            var options = new KafkaOptions(new Uri("http://sjkap556:9092"), new Uri("http://sjkap556:9092"));
            var router = new BrokerRouter(options);

            OffsetPosition[] offsetPositions = new OffsetPosition[]
                 {
                        new OffsetPosition()
                        {
                           Offset = 0,
                           PartitionId = 0
                        }
                 };

            var consumer = new KafkaNet.Consumer(new ConsumerOptions("testCockpit", new BrokerRouter(options)), offsetPositions);


            //Consume returns a blocking IEnumerable (ie: never ending stream)
            foreach (var message in consumer.Consume())
            {
                Console.WriteLine("Response: P{0},O{1} : {2}", message.Meta.PartitionId, message.Meta.Offset, Encoding.UTF8.GetString(message.Value));
            }

        }
    }
}
