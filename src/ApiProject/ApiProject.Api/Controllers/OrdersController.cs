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

		[HttpGet("GetOrder", Name = "GetOrder")]
		public async Task<IActionResult> GetOrder()
		{
			var order = await _orderHandler.GetOrders(new GetOrdersQuery(Guid.NewGuid()));
			if(order.Status == ResultStatus.Failed)
			{
				return Ok(CustomResult.Failure(order.Error));
			}
			return Ok(CustomResult.Success(order.Result));
		}

	}
}
