using ApiProject.Domain.Accounts;
using ApiProject.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Infrastructure.Repositories
{
	public sealed class AccountingRepository : IAccountingRepository
	{
		public decimal GetTaxAmount(Currency currency)
		{
			return 0.06m; // 6%
		}
	}
}
