﻿using ApiProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Api.Extensions
{
	public static class ApplicationBuilderExtensions
	{
		public static void ApplyMigrations(this IApplicationBuilder app)
		{
			using var scope = app.ApplicationServices.CreateScope();

			using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

			if (!dbContext.Database.IsInMemory())
			{
				dbContext.Database.Migrate();
			}
		}
	}
}
