using XmlParser.Entities;
using XmlParser.OperationResults;

namespace XmlParser.Services.Product;

public interface IProductService
{
    public OperationExecutionResult AddProduct(Entities.Product product);
}