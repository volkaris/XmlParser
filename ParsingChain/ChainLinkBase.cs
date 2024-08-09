using System.Xml.Linq;
using XmlParser.Entities;
using XmlParser.OperationResults;

namespace XmlParser.ParsingChain;

public  abstract class ChainLinkBase
{
    protected ChainLinkBase? _next;
    
    public void AddNext(ChainLinkBase link)
    {
        if (_next is null)
        {
            _next = link;
        }
        else
        {
            _next.AddNext(link);
        }
    }

    public abstract OperationExecutionResult ProcessOrder(OrderDto orderDto);
}