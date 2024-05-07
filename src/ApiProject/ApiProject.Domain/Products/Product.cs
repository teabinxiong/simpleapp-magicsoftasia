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

		public Price Price { get; private set; }

		public Category Category { get; private set; }

		public Price Tax { get; private set; }

		public Price AmountAfterTax { get; private set; }

		public DateTime CreatedOnUtc { get; private set; }
	}
}
