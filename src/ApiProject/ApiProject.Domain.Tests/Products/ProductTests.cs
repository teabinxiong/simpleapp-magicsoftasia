using ApiProject.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.Tests.Products
{
	public class ProductTests
	{

		[Fact]
		public void ProductsInitializeShouldBeValid()
		{
			Guid productId = Guid.NewGuid();
			DateTime utcNow = DateTime.UtcNow;

			Guid expectedProductId = productId;
			DateTime expectedUtc = utcNow;
			string expectedName = "Product Name 1";
			string expectedDescription = "Product Description 1";
			string expectedCategory = "Cloth";

			var _sut = Product.Create(
				productId,
				"Product Name 1",
				"Product Description 1",
				Money.From(10m, Currency.MYR),
				"Cloth",
				utcNow
			);

			Assert.Equal(expectedProductId, _sut.Id);
			Assert.Equal(expectedName, _sut.Name);
			Assert.Equal(expectedDescription, _sut.Description);
			Assert.Equal(expectedUtc, _sut.CreatedOnUtc);
			Assert.Equal(expectedCategory, _sut.Category);

		}
	}
}
