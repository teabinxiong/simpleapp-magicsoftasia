using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.Products
{
	public sealed class Category
    {
		public int CategoryId { get; private set; }
		public string Name { get; private set; }
		protected Category(int categoryId, string name)
		{
			CategoryId = categoryId;
			Name = name;
		}

		public Category Create(int categoryId, string name)
		{
			// validate the inputs
			if(name == string.Empty)
			{
				throw new InvalidOperationException("Category Name cannot be empty.");
			}

			return new Category(categoryId, name);
		}

	}
		
}
