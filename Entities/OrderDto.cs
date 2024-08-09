using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace XmlParser.Entities;

[XmlRoot("order")]
public class OrderDto
{
    public OrderDto()
    {
    }

    public OrderDto(int no, string regDate, double sum, List<Product> products, User user)
    {
        No = no;
        RegDate = regDate;
        Sum = sum;
        Products = products;
        User = user;
    }

    [XmlElement("no")] public int No { get; set; }

    [XmlElement("reg_date")] public string RegDate { get; set; }

    [XmlElement("sum")] public double Sum { get; set; }

    [XmlElement("product")] public List<Product> Products { get; set; }

    [XmlElement("user")] public User User { get; set; }
}