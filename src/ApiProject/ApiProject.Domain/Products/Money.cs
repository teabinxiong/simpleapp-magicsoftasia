using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.Products
{
	public record Money(decimal Amount, Currency Currency)
	{
		public static Money Zero() => new(0, Currency.None);

		public static Money Zero(Currency currency) => new(0, currency);

		public bool IsZero() => this == Zero();
	}
}
