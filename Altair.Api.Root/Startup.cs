using Altair.Api.Root.Modules;
using Altair.Core.Modules;
using Altair.Dal.Modules;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stars.Core.Modules;

namespace Altair.Api.Root
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			// ����������� ������������
			services
				.AddLoggerModule()
				.AddAltairMapperModule()
				.AddAltairCoreModule()
				.AddAltairDalModule()
				.AddControllers();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			// �������� ������������ �������
			var mapper = app.ApplicationServices.GetService<IMapper>();
			mapper.ConfigurationProvider.AssertConfigurationIsValid();

			// ����������� ���������
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGet("/", async context =>
				{
					await context.Response.WriteAsync("It works!");
				});

				endpoints.MapControllers();
			});
		}
	}
}
