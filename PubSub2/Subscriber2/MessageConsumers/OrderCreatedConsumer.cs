namespace Subscriber2.Consumers;

using System.Threading.Tasks;
using MassTransit;
using MessageContracts;
using Microsoft.Extensions.Logging;

public class OrderCreatedConsumer :
    IConsumer<OrderCreated>
{
    readonly ILogger<OrderCreatedConsumer> logger;

    public OrderCreatedConsumer(ILogger<OrderCreatedConsumer> logger)
    {
        this.logger = logger;
    }

    public Task Consume(ConsumeContext<OrderCreated> context)
    {
        logger.LogInformation("Received OrderCreated: {OrderNumber}", context.Message.OrderNumber);
        return Task.CompletedTask;
    }
}
