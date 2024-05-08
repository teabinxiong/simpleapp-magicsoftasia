using ApiProject.Domain.Abstractions;
using ApiProject.Service.Orders;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrdersController : ControllerBase
	{
		
		private readonly ILogger<OrdersController> _logger;

		private readonly IOrderHandler _orderHandler;

		public OrdersController(
			ILogger<OrdersController> logger,
			IOrderHandler orderHandler
			)
		{
			_logger = logger;
			_orderHandler = orderHandler;
		}

		[HttpGet("GetAllOrder", Name = "GetOrder")]
		public async Task<IActionResult> GetAllOrder()
		{
			var order = await _orderHandler.GetOrders(new GetAllOrdersQuery());
			if(order.Status == ResultStatus.Failed)
			{
				return Ok(CustomResult.Failure(order.Error));
			}
			return Ok(CustomResult.Success(order.Result));
		}

		[HttpPost("PlaceOrder", Name = "PlaceOrder")]
		public async Task<IActionResult> PlaceOrder([FromBody]PlaceOrderCommand placeOrderCommand)
		{
			var order = await _orderHandler.PlaceOrder(placeOrderCommand);
			if (order.Status == ResultStatus.Failed)
			{
				return Ok(CustomResult.Failure(order.Error));
			}
			return Ok(CustomResult.Success(order.Result));
		}

	}
}
