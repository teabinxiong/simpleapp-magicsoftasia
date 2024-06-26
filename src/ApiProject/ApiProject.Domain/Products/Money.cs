﻿using System;
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

		public static Money From(decimal amount, Currency currency)
		{
			return new Money(amount, currency);
		}

		public static Money operator +(Money first, Money second)
		{
			if (first.Currency != second.Currency)
			{
				throw new InvalidOperationException("Currencies have to be equal");
			}

			return new Money(first.Amount + second.Amount, first.Currency);
		}

	}
}
