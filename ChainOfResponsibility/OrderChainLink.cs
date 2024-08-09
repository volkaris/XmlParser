using XmlParser.Entities;
using XmlParser.OperationResults;
using XmlParser.Services.Order;

namespace XmlParser.ChainOfResponsibility;

public class OrderChainLink : ChainLinkBase
{
    private readonly IOrderService _orderService;

    public OrderChainLink(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public override OperationExecutionResult ProcessOrder(OrderDto orderDto)
    {
        return _orderService.AddOrder(orderDto);
    }
}