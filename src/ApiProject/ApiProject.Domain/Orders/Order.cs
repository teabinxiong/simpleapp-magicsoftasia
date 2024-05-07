using ApiProject.Domain.Abstractions;
using ApiProject.Domain.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.Orders
{
	public class Order: Entity
	{
		public List<Product> products { get;private set; }

		public Money TotalPrice
		{
			get
			{
				decimal totalPrice = products.Sum((a) => a.Price.Amount);
				return (products.Count == 0) ? 
					new Money(0, Currency.None):
					new Money(totalPrice, products.First().Price.Currency);
			}
		}

		public Money TotalPriceAfterTax
		{
			get
			{
				decimal totalPrice = products.Sum((a) => a.AmountAfterTax.Amount);
				return (products.Count == 0) ?
					new Money(0, Currency.None) :
					new Money(totalPrice, products.First().Price.Currency);
			}
		}

		public OrderStatus Status { get; private set; }

		public DateTime CreatedOnUtc { get; private set; }

		public DateTime ConfirmedOnUtc { get; private set; }

		public DateTime AcceptedOnUtc { get; private set; }

		public DateTime DeliveredOnUtc { get; private set; }

		public DateTime CompletedOnUtc { get; private set; }

		public DateTime CancelledOnUtc { get; private set; }
	}
}
