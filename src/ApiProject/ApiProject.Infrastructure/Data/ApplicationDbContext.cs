using ApiProject.Domain.Abstractions;
using ApiProject.Domain.Orders;
using ApiProject.Domain.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Infrastructure.Data
{
	public sealed class ApplicationDbContext : DbContext, IUnitOfWork
	{
		public DbSet<Order> Orders { get; set; }

		public DbSet<OrderItem> OrderItems { get; set; }

		public DbSet<Product> Products { get; set; }


		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			
		}

        public ApplicationDbContext()
        {
            
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

			base.OnModelCreating(modelBuilder);
		}

	}
}
