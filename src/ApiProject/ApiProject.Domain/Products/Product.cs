using ApiProject.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.Products
{
	public class Product: Entity
	{
		public string Name { get; private set; }

		public string Description { get; private set; }

		public Money Price { get; private set; }

		public Category Category { get; private set; }

		public Money Tax { get; private set; }

		public Money AmountAfterTax { get; private set; }

		public DateTime CreatedOnUtc { get; private set; }
	}
}
