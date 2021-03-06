﻿using Deneb.Core.DataServices.Interfaces;
using Deneb.Dal.Contexts;
using Deneb.Dal.DataModels;
using Deneb.Dal.DataServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Stars.Core.Services.Interfaces;
using Stars.Dal.EntityFramework.Repositories;
using Stars.Dal.EntityFramework.Repositories.Interfaces;

namespace Deneb.Dal.Modules
{
	public static class DenebDalModule
	{
		public static IServiceCollection AddDenebDalModule(this IServiceCollection services)
		{
			// Контексты баз данных
			services
				.AddDbContext<DenebDalContext>((serviceProvider, optionsBuilder) =>
				{
					var starsConfigurationService = serviceProvider.GetService<IStarsConfigurationService>();
					optionsBuilder.UseSqlServer(starsConfigurationService.Root.ConnectionStrings.Default);
				});

			// Репозитории
			services
				.AddScoped<
					IQueryableDataRepository<ReportDataModel>,
					DataRepository<ReportDataModel, DenebDalContext>>();

			// Data-сервисы
			services
				.AddScoped<IReportDataService, ReportDataService>();

			return services;
		}
	}
}
