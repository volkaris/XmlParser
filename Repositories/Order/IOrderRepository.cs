using XmlParser.OperationResults;

namespace XmlParser.Repositories.Order;

public interface IOrderRepository
{
    public OperationExecutionResult AddOrder(Entities.Order order);
}