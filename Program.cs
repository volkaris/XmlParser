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
        var serviceCollection = new ServiceCollection();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .Build();


        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IUserRepository, UserRepository>();

        serviceCollection.AddScoped<IOrderService, OrderService>();
        serviceCollection.AddScoped<IOrderRepository, OrderRepository>();

        serviceCollection.AddScoped<IOrderItemsService, OrderItemsService>();
        serviceCollection.AddScoped<IOrderItemRepository, OrderItemsRepository>();

        serviceCollection.AddScoped<IProductService, ProductService>();
        serviceCollection.AddScoped<IProductRepository, ProductRepository>();

        serviceCollection.AddDbContext<OrdersDbContext>(
            opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        var serviceProvider = serviceCollection.BuildServiceProvider();
        
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

        if (parsingResult is OperationExecutionResult.Unsuccess unsuccess)
        {
            Console.WriteLine(unsuccess.FailReason);
        }
    }
}