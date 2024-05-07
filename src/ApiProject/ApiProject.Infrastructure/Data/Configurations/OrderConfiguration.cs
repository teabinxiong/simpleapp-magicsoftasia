using ApiProject.Domain.Orders;
using ApiProject.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Infrastructure.Data.Configurations
{
	internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable("orders");

			builder.HasKey(order => order.Id);

			builder.HasMany(order => order.OrderItems)
				.WithOne()
				.HasForeignKey(orderItem => orderItem.OrderId);

			builder.OwnsOne(order => order.TotalPrice, priceBuilder =>
			{
				priceBuilder.Property(money => money.Currency)
				.HasConversion(currency => currency.Code, code => Currency.FromCode(code));
			});

			builder.OwnsOne(order => order.TotalPriceAfterTax, priceBuilder =>
			{
				priceBuilder.Property(money => money.Currency)
				.HasConversion(currency => currency.Code, code => Currency.FromCode(code));
			});

		}
	}
}
