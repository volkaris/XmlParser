using Microsoft.EntityFrameworkCore;
using XmlParser.ChainOfResponsibility;
using XmlParser.DbContexts;
using XmlParser.OperationResults;
using XmlParser.Parsers;
using XmlParser.Repositories.Order;
using XmlParser.Repositories.OrderItems;
using XmlParser.Repositories.Product;
using XmlParser.Repositories.Users;
using XmlParser.Services.Order;
using XmlParser.Services.OrderItems;
using XmlParser.Services.Product;
using XmlParser.Services.User;

namespace XmlParser;

internal class Program
{
    private static void Main()
    {
        var builder = WebApplication.CreateBuilder();

        builder.Services.AddDbContext<OrdersDbContext>(
            options =>
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();

        builder.Services.AddScoped<IOrderItemsService, OrderItemsService>();
        builder.Services.AddScoped<IOrderItemRepository, OrderItemsRepository>();

        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<OrdersDbContext>();
            dbContext.Database.Migrate();
        }

        using (var scope = app.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;

            var parser = new Parser("C:\\Users\\Ilya\\RiderProjects\\XmlParser\\XmlParser\\example.xml");

            var order = parser.OrderDto;

            var orderService = serviceProvider.GetRequiredService<IOrderService>();
            var userService = serviceProvider.GetRequiredService<IUserService>();
            var orderItemsService = serviceProvider.GetRequiredService<IOrderItemsService>();
            var productService = serviceProvider.GetRequiredService<IProductService>();

            var productChainLink = new ProductsChainLink(productService);
            var orderItemChainLink = new OrderItemsChainLink(orderItemsService);
            var userChainLink = new UsersChainLink(userService);
            var orderChainLink = new OrderChainLink(orderService);

            productChainLink.AddNext(userChainLink).AddNext(orderChainLink).AddNext(orderItemChainLink);

            var parsingResult = productChainLink.ProcessOrder(order);

            if (parsingResult is OperationExecutionResult.Unsuccess unsuccess) Console.WriteLine(unsuccess.FailReason);
        }
    }
}