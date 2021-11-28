using HomeworkStructPattern.Models;

namespace HomeworkStructPattern.Adapters
{
    class WearAdapter : IProduct
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public Wear Source { get; set; }

        public WearAdapter(Wear source)
        {
            Name = source.Title;
            Price = source.Price;
            Description = source.Description;
            Source = source;
        }
    }
}
