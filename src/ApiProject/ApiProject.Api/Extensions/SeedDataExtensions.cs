using ApiProject.Domain.Orders;
using ApiProject.Domain.Products;
using ApiProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Api.Extensions
{
	public static class SeedDataExtensions
	{
		public static void SeedData(this IApplicationBuilder app)
		{
			using var scope = app.ApplicationServices.CreateScope();
			var orderService = scope.ServiceProvider.GetRequiredService<OrderService>();
			using (var context = new ApplicationDbContext(
				scope.ServiceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
			{


				var product1 = Product.Create(
					Guid.NewGuid(),
					"Product A",
					"Product Description A",
					new Money(10.00m, Currency.SGD),
					"Category A",
					DateTime.UtcNow
					);

				var orderItem1 = OrderItem.Create(product1, 1);

				var order1 = Order.Place(
					new List<OrderItem>() { orderItem1 },
					0.06m,
					Guid.NewGuid(),
					DateTime.UtcNow,
					orderService
					);


				context.Add(
					order1
					);

				context.SaveChanges();

			}
		}
	}
}
