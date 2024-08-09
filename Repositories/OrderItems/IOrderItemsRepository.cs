using XmlParser.Entities;
using XmlParser.OperationResults;

namespace XmlParser.Repositories.OrderItems;

public interface IOrderItemRepository
{
    public OperationExecutionResult SaveOrderItem(OrderItem orderItem);
}