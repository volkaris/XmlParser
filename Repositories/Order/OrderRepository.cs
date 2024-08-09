using Microsoft.EntityFrameworkCore;
using XmlParser.DbContexts;
using XmlParser.OperationResults;

namespace XmlParser.Repositories.Order;

public class OrderRepository : IOrderRepository
{
    private readonly OrdersDbContext _context;

    public OrderRepository(OrdersDbContext context)
    {
        _context = context;
    }

    public OperationExecutionResult AddOrder(Entities.Order order)
    {
        try
        {
            _context.Add(order);
            _context.SaveChanges();
            return new OperationExecutionResult.Success();
        }
        catch (Exception e)
        {
            return new OperationExecutionResult.Unsuccess(e.ToString());
        }
    }
}