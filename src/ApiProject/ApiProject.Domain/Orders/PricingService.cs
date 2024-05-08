using ApiProject.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.Orders
{
	public sealed class PricingService
	{
		public PricingDetails CalculatePrice(List<OrderItem> orderItems, Decimal tax)
		{
			var totalPrice = Money.Zero();
			var totalPriceAfterTax = Money.Zero();
			var currency = orderItems.First().Product.Price.Currency;

			totalPrice = new Money(orderItems.Sum(a => a.Product.Price.Amount * a.Quantity), currency);
			totalPriceAfterTax = new Money(orderItems.Sum(a => (a.Product.Price.Amount * (1 - tax)) * a.Quantity), currency);

			return new PricingDetails(totalPrice, totalPriceAfterTax);
		}
	}
}
