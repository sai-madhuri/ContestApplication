using ContestApplication.Interfaces;
using ContestApplication.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetaPoco;
using PetaPoco.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContestApplication
{
    public class DependencyInjectionBootstrap
    {
        public static void InjectedServices(IConfiguration Configuration, IServiceCollection services)
        {
            services.AddScoped<IContestService, ContestService>();
            services.AddScoped<IActionService, ActionService>();

            services.AddSingleton<IDatabase>((a) =>
            {
                return DatabaseConfiguration.Build()
                     .UsingConnectionString(Configuration["ConnectionString"])
                     .UsingProvider<SqlServerDatabaseProvider>()
                     .Create();

            });
        }
    }
}
