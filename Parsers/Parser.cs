using System.Xml.Serialization;
using XmlParser.Entities;

namespace XmlParser.Parsers;

public class Parser
{
    private readonly string pathToXml;


    public Parser(string pathToXml)
    {
        this.pathToXml = pathToXml;
    }

    public OrderDto OrderDto
    {
        get
        {
            var orderSerializer = new XmlSerializer(typeof(OrderDto));
            
            var reader = new StreamReader(pathToXml);
            return orderSerializer.Deserialize(reader) as OrderDto ?? throw new InvalidOperationException("order can't be null");
        }
    }
}