using XmlParser.Entities;
using XmlParser.OperationResults;
using XmlParser.Services.Product;

namespace XmlParser.ChainOfResponsibility;

public class ProductsChainLink : ChainLinkBase
{
    private readonly IProductService _productService;

    public ProductsChainLink(IProductService productService)
    {
        _productService = productService;
    }

    public override OperationExecutionResult ProcessOrder(OrderDto orderDto)
    {
        foreach (var product in orderDto.Products)
        {
            var result = _productService.AddProduct(product);
            if (result is OperationExecutionResult.Unsuccess unsuccess)
                return unsuccess;
        }

        return _next is not null ? _next.ProcessOrder(orderDto) : new OperationExecutionResult.Success();
    }
}