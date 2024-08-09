using XmlParser.OperationResults;
using XmlParser.Repositories.Users;

namespace XmlParser.Services.User;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public OperationExecutionResult AddUser(Entities.User user)
    {
        return _userRepository.AddUser(user);
    }
}