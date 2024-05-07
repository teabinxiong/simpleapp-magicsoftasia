using ApiProject.Domain.Abstractions;
using ApiProject.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.Orders
{
	public sealed class OrderItem : Entity
	{

		public Money TotalAmount { get; private set; }

		public int Quantity { get; private set; }

		public Product Product { get; private set; }

		private OrderItem(Product product, int quantity, Money totalAmount) {
			Product = product;
			Quantity = quantity;
			TotalAmount = totalAmount;
		}

		public static OrderItem Create(Product product, int quantity)
		{
			// calculate total price
			decimal totalAmount = product.Price.Amount * quantity;

			// validate total amount
			if(totalAmount <= 0)
			{
				throw new ApplicationException("Total Amount cannot be zero");
			}

			return new OrderItem(product, quantity, new Money(totalAmount, product.Price.Currency));
		}

	}
}
