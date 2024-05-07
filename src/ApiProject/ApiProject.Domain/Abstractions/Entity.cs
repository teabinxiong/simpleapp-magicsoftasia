using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Domain.Abstractions
{
	public abstract class Entity
	{
		public long Id { get; set; }

		protected Entity()
		{

		}

		protected Entity(long id)
		{
			Id = id;
		}
	}
}
