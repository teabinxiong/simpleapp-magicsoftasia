using ApiProject.Domain.Orders;
using ApiProject.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.UnitTests.Orders
{
	public class OrderTests
	{
		[Fact]
		public void OrderTotalAmountIsValid()
		{
			decimal expectedTotalAmount = 80;
			decimal expectedTotalAmountWithTax = 72;

			var productA = Product.Create(
				Guid.NewGuid(),
				"product A",
				"product Description A",
				Money.From(10, Currency.SGD),
				"Cloth",
				DateTime.UtcNow
			);

			var productB = Product.Create(
				Guid.NewGuid(),
				"product B",
				"product Description B",
				Money.From(20, Currency.SGD),
				"Cloth",
				DateTime.UtcNow
			);

			List<OrderItem> orderItems = new List<OrderItem>();

			orderItems.Add(OrderItem.Create(productA, 2));

			orderItems.Add(OrderItem.Create(productB, 3));

			var order = Order.Place(orderItems, 0.10m, Guid.NewGuid(), DateTime.UtcNow, new PricingService());

			Assert.Equal(expectedTotalAmount, order.TotalPrice.Amount);
			Assert.Equal(expectedTotalAmountWithTax, order.TotalPriceAfterTax.Amount);

		}


		[Fact]
		public void CancelOrderAfterConfirmOrderShouldBeFailed()
		{
			var productA = Product.Create(
				Guid.NewGuid(),
				"product A",
				"product Description A",
				Money.From(10, Currency.SGD),
				"Cloth",
				DateTime.UtcNow
			);

			var productB = Product.Create(
				Guid.NewGuid(),
				"product B",
				"product Description B",
				Money.From(20, Currency.SGD),
				"Cloth",
				DateTime.UtcNow
			);

			List<OrderItem> orderItems = new List<OrderItem>();

			orderItems.Add(OrderItem.Create(productA, 2));

			orderItems.Add(OrderItem.Create(productB, 3));

			var order = Order.Place(orderItems, 0.10m, Guid.NewGuid(), DateTime.UtcNow, new PricingService());
			
			order.Confirm(DateTime.UtcNow);
			var cancelResult = order.Cancel(DateTime.UtcNow);
			
			Assert.Equal(OrderErrors.UnableToCancel.Code, cancelResult.Error.Code);
		
		}
	}
}
