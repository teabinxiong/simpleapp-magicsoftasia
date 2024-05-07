using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.Orders
{
	public interface IOrderRepository
	{
		bool IsOrderItemsValid(List<OrderItem> orderItems);
		Order GetOrderById(Guid id);

		void Add(Order order);
	}
}
