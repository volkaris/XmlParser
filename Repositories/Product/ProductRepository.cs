using XmlParser.DbContexts;
using XmlParser.OperationResults;

namespace XmlParser.Repositories.Product;

public class ProductRepository : IProductRepository
{
    private readonly OrdersDbContext _context;

    public ProductRepository(OrdersDbContext context)
    {
        _context = context;
    }


    public OperationExecutionResult AddProduct(Entities.Product product)
    {
        try
        {
            _context.Add(product);
            _context.SaveChanges();
            return new OperationExecutionResult.Success();
        }
        catch (Exception e)
        {
            return new OperationExecutionResult.Unsuccess(e.ToString());
        }
    }
}