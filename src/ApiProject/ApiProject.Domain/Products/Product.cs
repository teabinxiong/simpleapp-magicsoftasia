using ApiProject.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApiProject.Domain.Products
{
	public class Product: Entity
	{

		public string Name { get; private set; }

		public string Description { get; private set; }

		public Money Price { get; private set; }

		public string Category { get; private set; }

		public DateTime CreatedOnUtc { get; private set; }

		private Product()
		{

		}

		private Product(
			Guid id,
			string name,
			string description,
			Money price,
			string category,
			DateTime createdOnUtc
			)
		{
			Id = id;
			Name = name;
			Description = description;
			Price = price;
			Category = category;
			CreatedOnUtc = createdOnUtc;
		}

		public static Product Create(
			Guid id,
			string name,
			string description,
			Money price,
			string category,
			DateTime createdOnUtc
			)
		{
			return new Product(
			id,
			name,
			description,
			price,
			category,
			createdOnUtc
		);
		}

	}
}
