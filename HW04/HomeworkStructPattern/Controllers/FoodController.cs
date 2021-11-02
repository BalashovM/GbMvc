using HomeworkStructPattern.Models;
using HomeworkStructPattern.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace HomeworkStructPattern.Controllers
{
    public class FoodController : IProductController<Food>
    {
        private readonly ILogger<App> _logger;
        private readonly IRepositoryProduct<Food> _repository;

        public FoodController(ILogger<App> logger, IRepositoryProduct<Food> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async void AddProduct(Food product)
        {
            await _repository.WriteProduct(product);
        }

        public void AddProducts(List<Food> products)
        {
            _repository.WriteAllProducts(products);
        }

        public void GenerationProducts()
        {
            List<Food> products = new List<Food>();
            Random randomize = new Random();

            for (int i = 0; i < 5; i++)
            {
                products.Add(new Food($"FoodName_{i}", "kg", (float)randomize.Next(100, 10000), $"FoodSpecification_{i}", $"http://test.com//Food_{i}"));

            }

            AddProducts(products);
        }

        public List<Food> GetAllProducts()
        {
            return _repository.ReadProducts().Result;
        }
    }
}
