using ApiProject.Domain.Orders;
using ApiProject.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Service.Orders
{

	public class ProductDTO
	{
		public Guid ProductId { get;set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }

		public string Currency { get; set; }


		public string Category { get; set; }

		public int Quantity { get; set; }
		ProductDTO(Guid productId, string name, string description, decimal price, string currency, string category, int quantity)
		{
			ProductId = productId;
			Name = name;
			Description = description;
			Price = price;
			Currency = currency;
			Category = category;
			Quantity = quantity;
		}

        public ProductDTO()
        {
            
        }

    }


	public class PlaceOrderCommand
	{
        public List<ProductDTO> ProductItems { get; set; }
		public decimal Tax { get; set; }

		public Guid UserId { get; set; }
		PlaceOrderCommand(
			List<ProductDTO> productItems,
			decimal tax,
			Guid userId
		)
		{
			ProductItems = productItems;
			Tax = tax;
			UserId = userId;
		}

        public PlaceOrderCommand()
        {
            
        }
    }

	
}
