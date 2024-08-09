using XmlParser.Entities;
using XmlParser.OperationResults;
using XmlParser.Repositories.OrderItems;

namespace XmlParser.Services.OrderItems;

public class OrderItemsService : IOrderItemsService
{
    private readonly IOrderItemRepository _repository;

    public OrderItemsService(IOrderItemRepository repository)
    {
        _repository = repository;
    }

    public OperationExecutionResult AddOrderItem(OrderItem orderItem)
    {
        /*foreach (var product in orderDto.Products)
        {
            var result = _repository.SaveOrderItem(new OrderItem(orderDto.No, product.Id));
            if (result is OperationExecutionResult.Unsuccess unsuccess)
                return unsuccess;
        }

        return new OperationExecutionResult.Success();*/

        return _repository.SaveOrderItem(orderItem);
    }
}