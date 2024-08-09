using XmlParser.Entities;
using XmlParser.OperationResults;

namespace XmlParser.ChainOfResponsibility;

public  abstract class ChainLinkBase
{
    protected ChainLinkBase? _next;
    
    public ChainLinkBase AddNext(ChainLinkBase link)
    {
        if (_next is null)
        {
            _next = link;
        }
        else
        {
            _next.AddNext(link);
        }

        return this;
    }

    public abstract OperationExecutionResult ProcessOrder(OrderDto orderDto);
}