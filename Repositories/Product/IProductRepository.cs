using XmlParser.OperationResults;

namespace XmlParser.Repositories.Product;

public interface IProductRepository
{
    public OperationExecutionResult AddProduct(Entities.Product product);
}