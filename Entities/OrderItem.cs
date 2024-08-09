using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XmlParser.Entities;

public class OrderItem
{
    public OrderItem(int orderId, Guid productId)
    {
        Id = Guid.NewGuid();
        OrderId = orderId;
        ProductId = productId;
    }


    [Key] [Column("id")] public Guid Id { get; set; }

    [Required] [Column("orderId")] public int OrderId { get; set; }

    [Required] [Column("productId")] public Guid ProductId { get; set; }
}