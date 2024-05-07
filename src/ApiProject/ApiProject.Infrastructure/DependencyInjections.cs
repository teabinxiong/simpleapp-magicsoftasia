using ApiProject.Domain.Abstractions;
using ApiProject.Domain.Accounts;
using ApiProject.Domain.Orders;
using ApiProject.Infrastructure.Clock;
using ApiProject.Infrastructure.Data;
using ApiProject.Infrastructure.Repositories;
using ApiProject.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Infrastructure
{
	public static class DependencyInjections
	{
		public static IServiceCollection InstallInfrastructure(
			this IServiceCollection services,
			IConfiguration configuration)
		{

			services.AddTransient<IDateTimeProvider, DateTimeProvider>();

			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseInMemoryDatabase("ApiProject");
			});

			services.AddScoped<IOrderRepository, OrderRepository>();
			services.AddScoped<IAccountingRepository, AccountingRepository>(); 
			services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

			return services;
		}
	}
}
