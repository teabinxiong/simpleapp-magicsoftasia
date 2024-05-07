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
	internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("products");

			builder.HasKey(product => product.Id);

			builder.OwnsOne(product => product.Price, priceBuilder =>
			{
				priceBuilder.Property(money => money.Currency)
				.HasConversion(currency => currency.Code, code => Currency.FromCode(code));
			});

		}
	}
}
