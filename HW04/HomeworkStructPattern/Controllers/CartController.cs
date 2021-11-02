using HomeworkStructPattern.Models;
using HomeworkStructPattern.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace HomeworkStructPattern.Controllers
{
    class CartController : IController<IProduct>
    {
        private readonly ILogger<App> _logger;
        private readonly IRepository<IProduct> _repository;
        private float Sum { get; set; }

        public CartController(ILogger<App> logger, IRepository<IProduct> repository)
        {
            _logger = logger;
            _repository = repository;
            Sum = 0;
        }

        public void AddProduct(IProduct product)
        {
            _repository.WriteProduct(product);
        }

        public void ViewCart()
        {
            List<IProduct> products = GetAllProducts();


            foreach (IProduct product in products)
            {
                Console.WriteLine($"Name: {product.Name} Price: {product.Price}");
            }

            Console.WriteLine($"Total price = {Sum}");
        }

        public List<IProduct> GetAllProducts()
        {
            return _repository.ReadProducts().Result;
        }
    }
}
