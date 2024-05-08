using ApiProject.Domain.Orders;
using ApiProject.Service.Orders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Service
{
	public static class DependencyInjections
	{
		public static IServiceCollection InstallApplicationServices(this IServiceCollection services)
		{
			services.AddTransient<PricingService>();

			services.AddTransient<IOrderHandler, OrderHandler>();

			return services;
		}
	}
}
