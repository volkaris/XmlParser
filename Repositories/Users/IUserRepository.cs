using XmlParser.OperationResults;

namespace XmlParser.Repositories.Users;

public interface IUserRepository
{
    public OperationExecutionResult AddUser(Entities.User user);
}