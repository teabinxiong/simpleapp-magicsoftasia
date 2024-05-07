using ApiProject.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.Accounts
{
	public interface IAccountingRepository
	{
		decimal GetTaxAmount(Currency currency);
	}
}
