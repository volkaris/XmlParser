using Microsoft.EntityFrameworkCore;
using XmlParser.Entities;

namespace XmlParser.DbContexts;

public class OrdersDbContext : DbContext
{
    public OrdersDbContext(DbContextOptions<OrdersDbContext> contextOptions) : base(contextOptions)
    {
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
}