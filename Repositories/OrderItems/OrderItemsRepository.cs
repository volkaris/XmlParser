using XmlParser.DbContexts;
using XmlParser.Entities;
using XmlParser.OperationResults;

namespace XmlParser.Repositories.OrderItems;

public class OrderItemsRepository : IOrderItemRepository
{
    private readonly OrdersDbContext _context;

    public OrderItemsRepository(OrdersDbContext context)
    {
        _context = context;
    }

    public OperationExecutionResult SaveOrderItem(OrderItem orderItem)
    {
        try
        {
            _context.Add(orderItem);
            _context.SaveChanges();
            return new OperationExecutionResult.Success();
        }
        catch (Exception e)
        {
            return new OperationExecutionResult.Unsuccess(e.ToString());
        }
    }
}