using ApiProject.Domain.Abstractions;
using ApiProject.Infrastructure.Data;
using ApiProject.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Infrastructure.Repositories
{
	internal abstract class Repository<T> where T : Entity
	{

		protected readonly ApplicationDbContext DbContext;

		protected Repository(ApplicationDbContext dbContext)
		{

			DbContext = dbContext;
		}

		public async Task<List<T>> GetAll(
			CancellationToken cancellationToken = default)
		{
			return await Task.FromResult(DbContext
				.Set<T>().Include(DbContext.GetIncludePaths(typeof(T))).ToList());
		}

		public async Task<T?> GetByIdAsync(
			Guid id,
			CancellationToken cancellationToken = default)
		{
			return await DbContext
				.Set<T>()
				.FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
		}

		public void Add(T entity)
		{
			DbContext.Add(entity);
		}
	}
}
