using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using XmlParser.DbContexts;
using XmlParser.Entities;
using XmlParser.Repositories.Order;
using XmlParser.Repositories.Users;
using XmlParser.Services.Order;
using XmlParser.Services.User;

/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
*/


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

        serviceCollection.AddDbContext<OrdersDbContext>(
            opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var orderSerializer = new XmlSerializer(typeof(OrderDto));


        using (var reader =
               new StreamReader("C:\\Users\\Ilya\\RiderProjects\\XmlParser\\XmlParser\\example.xml"))
        {
            var order = (OrderDto)orderSerializer.Deserialize(reader);

            var orderService = serviceProvider.GetRequiredService<IOrderService>();
            var userService= serviceProvider.GetRequiredService<IUserService>();

            userService.AddUser(order.User);
            orderService.AddOrder(order);
        }

        /*var doc = XDocument.Load(@"C:\Users\Ilya\RiderProjects\XmlParser\XmlParser\example.xml");

        var order = doc.Element("order");
        var products = order?.Elements("product");

        if (products != null)
            foreach (var xElement in products)
            {
                Console.WriteLine(xElement);
            }*/

        var x = 10;
    }
}