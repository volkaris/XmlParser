using XmlParser.Entities;
using XmlParser.OperationResults;

namespace XmlParser.Services.Order;

public interface IOrderService
{
    public OperationExecutionResult AddOrder(OrderDto orderDto);
}