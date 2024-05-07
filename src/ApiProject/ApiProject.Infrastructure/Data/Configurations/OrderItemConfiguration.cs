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
	internal sealed class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
	{
		public void Configure(EntityTypeBuilder<OrderItem> builder)
		{
			builder.ToTable("orderitems");

			builder.HasKey(orderItem => orderItem.Id);

			builder.HasOne(orderItem => orderItem.Product)
				.WithMany()
				.HasForeignKey(orderItem => orderItem.ProductId);

			builder.OwnsOne(orderItem => orderItem.TotalAmount, priceBuilder =>
			{
				priceBuilder.Property(money => money.Currency)
				.HasConversion(currency => currency.Code, code => Currency.FromCode(code));
			});

			

		}
	}
}
