using XmlParser.DbContexts;
using XmlParser.Entities;
using XmlParser.OperationResults;

namespace XmlParser.Repositories.Users;

public class UserRepository : IUserRepository
{
    private readonly OrdersDbContext _context;

    public UserRepository(OrdersDbContext context)
    {
        _context = context;
    }

    public OperationExecutionResult AddUser(User user)
    {
        try
        {
            _context.Add(user);
            _context.SaveChanges();
            return new OperationExecutionResult.Success();
        }
        catch (Exception e)
        {
            return new OperationExecutionResult.Unsuccess(e.ToString());
        }
    }
}