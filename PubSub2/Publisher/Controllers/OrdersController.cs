using MassTransit;
using MessageContracts;
using Microsoft.AspNetCore.Mvc;

namespace Publisher.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private static int orderCount = 1;
    private readonly IPublishEndpoint publishEndpoint;

    public OrdersController(IPublishEndpoint publishEndpoint)
    {
        this.publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
    }

    [HttpPost]
    public async Task<ActionResult> Create()
    {
        await this.publishEndpoint.Publish(new OrderCreated { OrderNumber = $"{orderCount++}/2022" });
        return NoContent();
    }
}
