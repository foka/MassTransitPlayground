namespace Subscriber.Consumers;

using MassTransit;

public class OrderCreatedConsumerDefinition :
    ConsumerDefinition<OrderCreatedConsumer>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<OrderCreatedConsumer> consumerConfigurator)
    {
        endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
    }
}
