using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace XmlParser.Entities;

public class User
{
    public User(string fio, string email)
    {
        Id = new Guid();
        Fio = fio;
        Email = email;
    }

    public User()
    {
        Id = Guid.NewGuid();
    }
    [Key] 
    [XmlIgnore] 
    [Column("id")]
    public Guid Id { get; private set;}


    [XmlElement("fio")] 
    [Required]
    [Column("fio")]
    public string Fio { get; set; }

    [XmlElement("email")]
    [Required]
    [Column("email")]
    public string Email { get; set; }
}