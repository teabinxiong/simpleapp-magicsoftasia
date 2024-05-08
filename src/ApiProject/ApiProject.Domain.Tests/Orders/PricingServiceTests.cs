using ApiProject.Domain.Orders;
using ApiProject.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.Tests.Orders
{
	public class PricingServiceTests
	{
		[Fact]
		public void PricingCalculateShouldBeValid()
		{
			var expectedTotalPrice = 80;
			var expectedTotalPriceIncludeTax = 80;
			var expectedCurrency = "SGD";

			var productA = Product.Create(
				Guid.NewGuid(),
				"product A",
				"product Description A",
				Money.From(10,Currency.SGD),
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

			var pricingService = new PricingService();

			var _sut = pricingService.CalculatePrice(orderItems, 0);

			Assert.Equal(expectedTotalPrice, _sut.TotalPrice.Amount);
			Assert.Equal(expectedTotalPriceIncludeTax, _sut.TotalPriceAfterTax.Amount);

			Assert.Equal(expectedTotalPrice, _sut.TotalPrice.Amount);
			Assert.Equal(expectedTotalPriceIncludeTax, _sut.TotalPriceAfterTax.Amount);

			Assert.Equal(expectedCurrency, _sut.TotalPrice.Currency.Code);
			Assert.Equal(expectedCurrency, _sut.TotalPriceAfterTax.Currency.Code);
		}

	}
}
