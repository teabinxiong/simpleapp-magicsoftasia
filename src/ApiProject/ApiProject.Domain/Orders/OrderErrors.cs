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
	}
}
