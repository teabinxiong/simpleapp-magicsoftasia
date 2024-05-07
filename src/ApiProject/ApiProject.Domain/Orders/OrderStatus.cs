using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.Orders
{
	public enum OrderStatus
	{ 
		Confirmed = 1,
		Accepted = 2,
		Delivered = 3,
		Cancelled = 4,
		Completed = 5
	}
}
