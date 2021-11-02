using HomeworkStructPattern.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace HomeworkStructPattern.Repositories
{
    class WearRepository : IRepositoryProduct<Wear>
    {
        private string _pathToFile;
        private readonly ILogger<App> _logger;

        public WearRepository(IOptions<AppSettings> appSettings, ILogger<App> logger)
        {
            _logger = logger;
            _pathToFile = appSettings.Value.PathWearRepo;
        }

        public async Task WriteProduct(Wear product)
        {
            using (FileStream fs = new FileStream(_pathToFile, FileMode.Append))
            {
                await JsonSerializer.SerializeAsync<Wear>(fs, product);
            }
        }

        public async Task WriteAllProducts(List<Wear> products)
        {
            using FileStream createStream = File.Create(_pathToFile);
            await JsonSerializer.SerializeAsync(createStream, products);
        }

        public async Task<List<Wear>> ReadProducts()
        {
            using FileStream openStream = File.OpenRead(_pathToFile);
            List<Wear> products = await JsonSerializer.DeserializeAsync<List<Wear>>(openStream);

            return products;
        }
    }
}
