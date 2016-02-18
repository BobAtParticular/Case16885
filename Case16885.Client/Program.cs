using System;
using Case16885.Messages;
using NServiceBus;

namespace Case16885.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var busConfiguration = new BusConfiguration();
            busConfiguration.UseTransport<RabbitMQTransport>()
                .ConnectionString("host=RABBITMQ");
            busConfiguration.Conventions().DefiningCommandsAs(t => t.Namespace != null && t.Namespace.EndsWith(".Messages"));

            busConfiguration.UseSerialization<JsonSerializer>();

            using (var bus = Bus.CreateSendOnly(busConfiguration))
            {
                Console.WriteLine("Press any key to send a message");
                while (Console.ReadLine() != null)
                {
                    var id = Guid.NewGuid();
                    bus.Send<CaseMessage>("Case16885.Host", cmd =>
                    {
                        cmd.Id = id;
                    });

                    Console.WriteLine("Sending message with id: " + id);
                }
            }
        }
    }
}
