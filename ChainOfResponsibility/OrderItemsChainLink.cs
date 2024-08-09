using XmlParser.Entities;
using XmlParser.OperationResults;
using XmlParser.Services.OrderItems;

namespace XmlParser.ChainOfResponsibility;

public class OrderItemsChainLink : ChainLinkBase
{
    private readonly IOrderItemsService _orderItemsService;

    public OrderItemsChainLink(IOrderItemsService orderService)
    {
        _orderItemsService = orderService;
    }

    public override OperationExecutionResult ProcessOrder(OrderDto orderDto)
    {
        foreach (var product in orderDto.Products)
        {
            var result = _orderItemsService.AddOrderItem(new OrderItem(orderDto.No, product.Id));
            
            if (result is OperationExecutionResult.Unsuccess unsuccess)
                return unsuccess;
        }

        return _next is not null ? _next.ProcessOrder(orderDto) : new OperationExecutionResult.Success();
    }
}