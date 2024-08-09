using XmlParser.Entities;
using XmlParser.OperationResults;
using XmlParser.Repositories.Order;

namespace XmlParser.Services.Order;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public OperationExecutionResult AddOrder(OrderDto orderDto)
    {
        return _repository.AddOrder(new Entities.Order(orderDto.No, orderDto.RegDate, orderDto.Sum,orderDto.User.Id));
    }
}