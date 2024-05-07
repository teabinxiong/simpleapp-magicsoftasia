using ApiProject.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.Products
{
	public static class ProductErrors
	{
		public static Error NotFound = new(
			"Product.NotFound",
			"The product with the specified id was not found"
			);
	}
}
