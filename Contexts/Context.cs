namespace XmlParser.Contexts;

internal class Context
{
    public Context(string? currentUserId, string? currentOrderId, IEnumerable<int> productsId)
    {
        CurrentUserId = currentUserId;
        CurrentOrderId = currentOrderId;
        ProductsId = productsId;
    }

    public string? CurrentUserId { get; }
    public string? CurrentOrderId { get; }
    public IEnumerable<int> ProductsId { get; }
}