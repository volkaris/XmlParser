using XmlParser.OperationResults;

namespace XmlParser.Services.User;

public interface IUserService
{
    public OperationExecutionResult AddUser(Entities.User user);
}