using HomeworkStructPattern.Models;
using HomeworkStructPattern.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace HomeworkStructPattern.Controllers
{
    public class WearController : IProductController<Wear>
    {
        private readonly ILogger<App> _logger;
        private readonly IRepositoryProduct<Wear> _repository;

        public WearController(ILogger<App> logger, IRepositoryProduct<Wear> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async void AddProduct(Wear product)
        {
            await _repository.WriteProduct(product);
        }

        public void AddProducts(List<Wear> products)
        {
            _repository.WriteAllProducts(products);
        }

        public void GenerationProducts()
        {
            List<Wear> products = new List<Wear>();
            Random randomize = new Random();

            for (int i = 0; i < 5; i++)
            {
                products.Add(new Wear($"WearName_{i}", 
                                      (int)randomize.Next(1, 70), 
                                      (float)randomize.Next(100, 10000),
                                      $"WearDescription_{i} ",
                                      $"http://test.com//Wear_{i}"));
            }

            AddProducts(products);
        }

        public List<Wear> GetAllProducts()
        {
            return _repository.ReadProducts().Result;
        }
    }
}
