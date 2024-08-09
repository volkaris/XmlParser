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
        var result = _orderService.AddOrder(orderDto);
        if (result is OperationExecutionResult.Unsuccess unsuccess)
            return unsuccess;
        return _next is not null ? _next.ProcessOrder(orderDto) : new OperationExecutionResult.Success();
    }
}