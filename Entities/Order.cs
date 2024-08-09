using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XmlParser.Entities;


public class Order
{
    private Order()
    {
        
    }

    public Order(int no, string regDate, double sum, Guid userId)
    {
        No = no;
        RegDate = regDate;
        Sum = sum;
        UserId = userId;
    }

    [Key]
    [Column("id")]
    public int No { get; set; }

    [Required]
    [Column("regDate")]
    public string RegDate { get; set; }

    [Required] 
    [Column("Sum")]
    public double Sum { get; set; }

    [Required] 
    [Column("user_id")]
    public Guid UserId { get; set; }
}