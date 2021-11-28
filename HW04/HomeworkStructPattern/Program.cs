using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace HomeworkStructPattern
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            // create service provider
            var serviceProvider = new ConfigurationServices().Services.BuildServiceProvider();

            // entry to run app
            await serviceProvider.GetService<App>().Run(args);
        }
    }
}


