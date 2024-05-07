using ApiProject.Domain.Abstractions;
using ApiProject.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Service.Orders
{
	public interface IOrderHandler
	{
		CustomResult<Guid> PlaceOrder(PlaceOrderCommand placeOrderCommand);

		Task<CustomResult<List<Order>>> GetOrders(GetOrdersQuery getOrderQuery, CancellationToken ct = default);
	}
}
