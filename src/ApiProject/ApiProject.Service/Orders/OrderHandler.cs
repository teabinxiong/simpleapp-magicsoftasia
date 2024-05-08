using ApiProject.Domain.Abstractions;
using ApiProject.Domain.Accounts;
using ApiProject.Domain.Orders;
using ApiProject.Domain.Products;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Service.Orders
{
	public sealed class OrderHandler : IOrderHandler
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IAccountingRepository _accountingRepository;
		private readonly PricingService _orderService;
		private readonly IDateTimeProvider _dateTimeProvider;
		private readonly IUnitOfWork _unitOfWork;
		public OrderHandler(
			IOrderRepository orderRepository,
			IAccountingRepository accountingRepository,
			PricingService orderService,
			IDateTimeProvider dateTimeProvider, 
			IUnitOfWork unitOfWork
			)
        {
			_orderRepository = orderRepository;
			_accountingRepository = accountingRepository;
			_orderService = orderService;
			_dateTimeProvider = dateTimeProvider;
			_unitOfWork = unitOfWork;
		}

		// Get Order
		public async  Task<CustomResult<List<Order>>> GetOrders(GetAllOrdersQuery getOrdersQuery, CancellationToken ct = default)
		{
			var order = await _orderRepository.GetAll(ct);

			if(order == null)
			{
				return CustomResult.Failure<List<Order>>(OrderErrors.NotFound);
			}

			return order;
		}

		// Place Order
		public async Task<CustomResult<Guid>> PlaceOrder(PlaceOrderCommand placeOrderCommand)
		{
			// Get tax
			_accountingRepository.GetTaxAmount(Currency.SGD);

			var orderItems = new List<OrderItem>();

			// compose order items
			foreach(var item in placeOrderCommand.ProductItems)
			{
				orderItems.Add(OrderItem.Create(
					Product.Create(
						item.ProductId,
						item.Name,
						item.Description,
						new Money(item.Price, Currency.FromCode(item.Currency)),
						item.Category,
						_dateTimeProvider.UtcNow()
						),
					item.Quantity
					));
			}


			var order = Order.Place(
					orderItems,
					placeOrderCommand.Tax,
					placeOrderCommand.UserId,
					_dateTimeProvider.UtcNow(),
					_orderService);

			// Add Order
			_orderRepository.Add(order);

			await _unitOfWork.SaveChangesAsync();

			return order.Id;

		}

      
    }
}
