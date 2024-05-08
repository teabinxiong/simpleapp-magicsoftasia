using ApiProject.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.UnitTests.Products
{
	public class CurrencyTests
	{

		[Fact]
		public void CurrencySGDShouldMatches()
		{
			Currency expectedCurrency = Currency.SGD;

			var _sut = Currency.FromCode("SGD");

			Assert.Equal(expectedCurrency.Code, _sut.Code);
		}

		[Fact]
		public void CurrencyMYRShouldMatches()
		{

			Currency expectedCurrency = Currency.MYR;

			var _sut = Currency.FromCode("MYR");

			Assert.Equal(expectedCurrency.Code, _sut.Code);
		}



	}
}
