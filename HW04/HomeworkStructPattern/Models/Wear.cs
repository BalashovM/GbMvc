namespace HomeworkStructPattern.Models
{
    public class Wear
    {
        public string Title { get; set; }
        public float Size { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

        public Wear(string title, float size, float price, string description, string link)
        {
            Title = title;
            Size = size;
            Price = price;
            Description = description;
            Link = link;
        }
    }
}
