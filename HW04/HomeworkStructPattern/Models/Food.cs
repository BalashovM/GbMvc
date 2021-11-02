namespace HomeworkStructPattern.Models
{
    public class Food
    {
        public string Title { get; set; }
        public string Measure { get; set; }
        public float Price { get; set; }
        public string Specification { get; set; }
        public string Link { get; set; }

        public Food(string title, string measure, float price, string specification, string link)
        {
            Title = title;
            Measure = measure;
            Price = price;            
            Specification = specification;
            Link = link;
        }
    }
}
