
namespace Case16885.Host
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.EndpointName("Case16885.Host");
            configuration.UseTransport<RabbitMQTransport>()
                .ConnectionString("host=RABBITMQ");

            configuration.Conventions().DefiningCommandsAs(t => t.Namespace != null && t.Namespace.EndsWith(".Messages"));

            configuration.UseSerialization<JsonSerializer>();

            configuration.UsePersistence<InMemoryPersistence>();
        }
    }
}
