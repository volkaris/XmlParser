using XmlParser.Entities;
using XmlParser.OperationResults;
using XmlParser.Services.User;

namespace XmlParser.ChainOfResponsibility;

public class UsersChainLink : ChainLinkBase
{
    private readonly IUserService _userService;

    public UsersChainLink(IUserService userService)
    {
        _userService = userService;
    }

    public override OperationExecutionResult ProcessOrder(OrderDto orderDto)
    {
        return _userService.AddUser(orderDto.User);
    }
}