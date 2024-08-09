using XmlParser.OperationResults;
using XmlParser.Repositories.Product;

namespace XmlParser.Services.Product;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public OperationExecutionResult AddProduct(Entities.Product product)
    {
        return _repository.AddProduct(product);
    }
}