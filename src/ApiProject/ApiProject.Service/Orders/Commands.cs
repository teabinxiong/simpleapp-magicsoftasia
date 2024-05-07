using ApiProject.Domain.Orders;
using ApiProject.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Service.Orders
{
	public record PlaceOrderCommand(
			List<OrderItem> OrderItems,
			decimal Tax,
			Guid UserId
		);
}
