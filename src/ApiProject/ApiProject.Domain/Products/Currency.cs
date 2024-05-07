using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.Products
{
	public record Currency
	{
		public static readonly Currency None = new("");

		public static readonly Currency MYR = new("MYR");

		public static readonly Currency SGD = new("SGD");

		private Currency(string code) => Code = code;

		public string Code { get; set; }

		public static Currency FromCode(string code)
		{
			return AllCurrency.FirstOrDefault(c => c.Code == code) ?? throw new ApplicationException("The currency code is invalid");
		}

		public static readonly IReadOnlyCollection<Currency> AllCurrency = new List<Currency>
		{
			MYR,
			SGD
		};
	}
}
