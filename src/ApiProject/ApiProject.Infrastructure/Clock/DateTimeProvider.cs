using ApiProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Infrastructure.Clock
{
	internal sealed class DateTimeProvider : IDateTimeProvider
	{
		public DateTime UtcNow()
		{
			return DateTime.UtcNow;
		}
	}
}
