using ApiProject.Domain.Abstractions;
using ApiProject.Domain.Accounts;
using ApiProject.Domain.Orders;
using ApiProject.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Service.Orders
{
	public sealed class OrderHandler : IOrderHandler
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IAccountingRepository _accountingRepository;
		private readonly OrderService _orderService;
		private readonly IDateTimeProvider _dateTimeProvider;
		public OrderHandler(
			IOrderRepository orderRepository,
			IAccountingRepository accountingRepository,
			OrderService orderService,
			IDateTimeProvider dateTimeProvider
			)
        {
			_orderRepository = orderRepository;
			_accountingRepository = accountingRepository;
			_orderService = orderService;
			_dateTimeProvider = dateTimeProvider;
		}

		// Get Order
		public CustomResult<Order> GetOrder(GetOrderQuery getOrderQuery)
		{
			var order =  _orderRepository.GetOrderById(getOrderQuery.Id);

			if(order == null)
			{
				return CustomResult.Failure<Order>(OrderErrors.NotFound);
			}

			return order;
		}

		// Place Order
		public CustomResult<Guid> PlaceOrder(PlaceOrderCommand placeOrderCommand)
		{
			// Get tax
			_accountingRepository.GetTaxAmount(Currency.SGD);

			// verify if order items is valid
			if (!_orderRepository.IsOrderItemsValid(placeOrderCommand.OrderItems))
			{
				return CustomResult.Failure<Guid>(OrderErrors.InvalidOrderItems);
			}

			var order = Order.Place(
					placeOrderCommand.OrderItems,
					placeOrderCommand.Tax,
					placeOrderCommand.UserId,
					_dateTimeProvider.UtcNow(),
					_orderService);

			// Add Order
			_orderRepository.Add(order);

			return order.Id;

		}

      
    }
}
