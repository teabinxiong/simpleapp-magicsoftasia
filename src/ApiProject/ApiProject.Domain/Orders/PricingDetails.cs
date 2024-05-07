using ApiProject.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.Orders
{
	public record PricingDetails(
	   Money TotalPrice,
	   Money TotalPriceAfterTax
	 );
}
