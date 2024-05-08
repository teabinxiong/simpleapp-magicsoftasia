using ApiProject.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.Tests.Products
{
	public class MoneyTests
	{

		[Fact]
		public void MoneySGDZeroShouldMatches()
		{
			
			decimal expectedAmount = 0;
			string expectedCode = "SGD";

			var _sut = Money.Zero(Currency.SGD);

			Assert.Equal(expectedAmount, _sut.Amount);
			Assert.Equal(Currency.FromCode(expectedCode), _sut.Currency);
		}

		[Fact]
		public void MoneyMYRZeroShouldMatches()
		{

			decimal expectedAmount = 0;
			string expectedCode = "MYR";

			var _sut = Money.Zero(Currency.MYR);

			Assert.Equal(expectedAmount, _sut.Amount);
			Assert.Equal(Currency.FromCode(expectedCode), _sut.Currency);
		}

		[Fact]
		public void MoneyMYRShouldMatches()
		{

			decimal expectedAmount = 10;
			string expectedCode = "MYR";

			var _sut = Money.From(10m, Currency.MYR);

			Assert.Equal(expectedAmount, _sut.Amount);
			Assert.Equal(Currency.FromCode(expectedCode), _sut.Currency);
		}

	}
}
