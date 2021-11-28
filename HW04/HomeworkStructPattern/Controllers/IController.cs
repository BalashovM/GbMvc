using System.Collections.Generic;

namespace HomeworkStructPattern.Controllers
{
    public interface IController<T>
    {
        public List<T> GetAllProducts();
        public void AddProduct (T t);
    }
}
