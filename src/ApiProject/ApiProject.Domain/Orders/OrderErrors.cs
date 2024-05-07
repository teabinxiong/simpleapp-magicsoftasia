using ApiProject.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.Orders
{
	public static class OrderErrors
	{
		public static Error NotFound = new("Order.NotFound", "The order with the specified id was not found");

		public static Error NotAccepted = new("Order.NotAccepted", "The order is not pending");

		public static Error InvalidOrderItems = new("Order.InvalidOrderItems", "One or more of the order items is not valid");
	}
}
