using XmlParser.Entities;
using XmlParser.OperationResults;

namespace XmlParser.Services.OrderItems;

public interface IOrderItemsService
{
    public OperationExecutionResult AddOrderItem(OrderItem orderItem);
}