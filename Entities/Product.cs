using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace XmlParser.Entities;

public class Product
{
    public Product(int quantity, string name, double price)
    {
        Id = new Guid();
        this.quantity = quantity;
        this.name = name;
        this.price = price;
    }

    public Product()
    {
        Id = Guid.NewGuid();
    }
    
    [XmlIgnore]
    [Key]
    public Guid Id { get; private set; }

    [XmlElement("quantity")] 
    [Required]
    public int quantity { get; set; }

    
    [XmlElement("name")]
    [Required]
    public string name { get; set; }

    [XmlElement("price")] 
    [Required]
    public double price { get; set; }
}