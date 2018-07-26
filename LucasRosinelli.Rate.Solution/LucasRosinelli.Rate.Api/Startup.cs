using LucasRosinelli.Rate.ApplicationService;
using LucasRosinelli.Rate.Domain.Contracts.ApplicationServices;
using LucasRosinelli.Rate.Domain.Contracts.Repositories;
using LucasRosinelli.Rate.Infrastructure.Persistence;
using LucasRosinelli.Rate.Infrastructure.Persistence.DataContext;
using LucasRosinelli.Rate.Infrastructure.Repository;
using LucasRosinelli.Rate.SharedKernel.Contracts;
using LucasRosinelli.Rate.SharedKernel.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LucasRosinelli.Rate.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Enables caching
            services.AddResponseCaching();
            services.AddMvc();

            services.AddSingleton<IDataContext, RateDataContextFromEcbXml>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IReferenceStatisticRepository, ReferenceStatisticRepository>();
            services.AddTransient<IReferenceStatisticApplicationService, ReferenceStatisticApplicationService>();
            services.AddSingleton<IHandler<DomainNotification>, DomainNotificationHandler>();

            var serviceProvider = services.BuildServiceProvider();
            DomainEvent.Container = new DomainEventsContainer(serviceProvider);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseResponseCaching();

            app.UseMvc(routes =>
            {
                // Configures a route which requires the controller and assumes "Get" as default action
                routes.MapRoute("MandatoryControllerOptionalAction", "{controller}/{action=Get}");
            });
        }
    }
}