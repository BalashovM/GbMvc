using HomeworkStructPattern.Models;

namespace HomeworkStructPattern.Adapters
{
    class FoodAdapter : IProduct
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public Food Source { get; set; }

        public FoodAdapter(Food source)
        {
            Name = source.Title;
            Price = source.Price;
            Description = source.Specification;
            Source = source;
        }
    }
}
