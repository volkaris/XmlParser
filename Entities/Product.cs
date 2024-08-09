using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace XmlParser.Entities;

public class Product
{
    public Product(int quantity, string name, double price)
    {
        Id = new Guid();
        this.Quantity = quantity;
        this.Name = name;
        this.Price = price;
    }

    public Product()
    {
        Id = Guid.NewGuid();
    }
    
    [XmlIgnore]
    [Key]
    [Column("id")]
    public Guid Id { get; private set; }

    [XmlElement("quantity")] 
    [Required]
    [Column("quantity")]
    public int Quantity { get; set; }

    
    [XmlElement("name")]
    [Required]
    [Column("name")]
    public string Name { get; set; }

    [XmlElement("price")] 
    [Required]
    [Column("price")]
    public double Price { get; set; }
}