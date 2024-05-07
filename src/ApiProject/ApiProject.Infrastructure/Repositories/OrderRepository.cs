using ApiProject.Domain.Orders;
using ApiProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Infrastructure.Repositories
{
	internal sealed class OrderRepository : Repository<Order>, IOrderRepository
	{
		private readonly ApplicationDbContext _dbContext;
		public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

	
		public bool IsOrderItemsValid(List<OrderItem> orderItems)
		{
			var targetProductIds = orderItems.Select(x => x.Product).Select(x => x.Id).ToList();

			var orders =  _dbContext.Orders.Include(o => o.OrderItems.Select(x => x.Product)).AsQueryable();
			
			return orders.All(x => targetProductIds.Contains(x.Id));
		}
	}
}
