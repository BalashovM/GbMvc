using HomeworkStructPattern.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace HomeworkStructPattern.Repositories
{
    class FoodRepository : IRepositoryProduct<Food>
    {
        private string _pathToFile;
        private readonly ILogger<App> _logger;

        public FoodRepository(IOptions<AppSettings> appSettings, ILogger<App> logger)
        {
            _logger = logger;
            _pathToFile = appSettings.Value.PathFoodRepo;
        }

        public async Task WriteProduct(Food product)
        {
            using (FileStream fs = new FileStream(_pathToFile, FileMode.Append))
            {
                await JsonSerializer.SerializeAsync<Food>(fs, product);
            }
        }

        public async Task WriteAllProducts(List<Food> products)
        {
            using FileStream createStream = File.Create(_pathToFile);
            await JsonSerializer.SerializeAsync(createStream, products);
        }

        public async Task<List<Food>> ReadProducts()
        {
            using FileStream openStream = File.OpenRead(_pathToFile);
            List<Food> products = await JsonSerializer.DeserializeAsync<List<Food>>(openStream);

            return products;
        }
    }
}
