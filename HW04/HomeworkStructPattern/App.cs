using HomeworkStructPattern.Adapters;
using HomeworkStructPattern.Controllers;
using HomeworkStructPattern.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeworkStructPattern
{
    public class App
    {
        private readonly ILogger<App> _logger;
        private IProductController<Wear> _wearController;
        private IProductController<Food> _foodController;
        private IController<IProduct> _cartController;

        public App(ILogger<App> logger, 
                   IProductController<Wear> wearController, 
                   IProductController<Food> foodController, 
                   IController<IProduct> cartController)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _wearController = wearController;
            _foodController = foodController;
            _cartController = cartController;
        }

        public async Task Run(string[] args)
        {
            _logger.LogInformation("Starting...");

            _foodController.GenerationProducts();
            _wearController.GenerationProducts();

            List<Food> foods = _foodController.GetAllProducts();
            List<Wear> wears = _wearController.GetAllProducts();

            foreach (Wear product in wears)
            {
                _cartController.AddProduct(new WearAdapter(product));
            }

            foreach (Food product in foods)
            {
                _cartController.AddProduct(new FoodAdapter(product));
            }

            _logger.LogInformation("Finish !!!");
            Console.Read();
            await Task.CompletedTask;
        }
    }
}
