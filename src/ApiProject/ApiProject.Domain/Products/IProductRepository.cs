using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.Products
{
	public interface IProductRepository
	{
		Task<Product?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
	}
}
