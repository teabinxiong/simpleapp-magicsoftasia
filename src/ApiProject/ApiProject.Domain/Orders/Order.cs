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
	public sealed class Order: Entity
	{
		private Order()
		{

		}

		private Order(
			Guid id,
			List<OrderItem> orderItems,
			OrderStatus status,
			Money tax,
			DateTime createdOnUtc,
			Guid userId
			)
		{
			Id = id;
			Tax = tax;
			OrderItems = orderItems;
			Status = status;
			CreatedOnUtc = createdOnUtc;
			UserId = userId;
		}

		public List<OrderItem> OrderItems { get;private set; }

		public Money Tax { get; private set; }

		public Money TotalPrice { get; private set; }

		public Money TotalPriceAfterTax { get; private set; }

		public OrderStatus Status { get; private set; }

		public Guid UserId { get; private set; }

		public DateTime CreatedOnUtc { get; private set; }

		public DateTime ConfirmedOnUtc { get; private set; }

		public DateTime AcceptedOnUtc { get; private set; }

		public DateTime DeliveredOnUtc { get; private set; }

		public DateTime CompletedOnUtc { get; private set; }

		public DateTime CancelledOnUtc { get; private set; }


		public static Order Place(
			List<OrderItem> orderItems,
			Money tax,
			Guid userId,
			DateTime utcNow
			)
		{
			// calculate total price & total price after tax


			// 
			var order = new Order(
				Guid.NewGuid(),
				orderItems,
				OrderStatus.Accepted,
				tax,
				utcNow,
				userId
				);

			return order;
		}
	}
}
