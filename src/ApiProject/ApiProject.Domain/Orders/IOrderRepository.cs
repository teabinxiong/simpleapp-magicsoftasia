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
		Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

		void Add(Order order);

		Task<List<Order>> GetAll(
		   CancellationToken cancellationToken = default);
	}
}
