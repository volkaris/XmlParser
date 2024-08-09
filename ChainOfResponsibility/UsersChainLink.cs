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
        var result = _userService.AddUser(orderDto.User);
        if (result is OperationExecutionResult.Unsuccess unsuccess)
            return unsuccess;
        return _next is not null ? _next.ProcessOrder(orderDto) : new OperationExecutionResult.Success();
    }
}