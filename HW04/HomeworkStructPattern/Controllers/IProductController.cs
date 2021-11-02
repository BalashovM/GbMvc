namespace HomeworkStructPattern.Controllers
{
    public interface IProductController<T> : IController<T>
    {
        public void GenerationProducts();
    }
}
