using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Service
{
	public interface IDateTimeProvider
	{
		DateTime UtcNow();
	}
}
