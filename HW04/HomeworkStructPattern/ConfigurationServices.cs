using HomeworkStructPattern.Controllers;
using HomeworkStructPattern.Models;
using HomeworkStructPattern.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;

namespace HomeworkStructPattern
{
    class ConfigurationServices
    {
        public ServiceCollection Services { get; set; }

        public ConfigurationServices()
        {
            Services = new ServiceCollection();
            ConfigureServices(Services);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // configure logging
            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            });

            // build config
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            services.Configure<AppSettings>(configuration.GetSection("App"));
            services.AddTransient<IRepositoryProduct<Wear>, WearRepository>();
            services.AddTransient<IRepositoryProduct<Food>, FoodRepository>();
            services.AddTransient<IRepository<IProduct>, СartRepository>();
            services.AddTransient<IProductController<Wear>, WearController>();
            services.AddTransient<IProductController<Food>, FoodController>();
            services.AddTransient<IController<IProduct>, CartController>();

            // add app
            services.AddTransient<App>();
        }
    }
}
