using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeworkStructPattern.Repositories
{
    public interface IRepository<T>
    {
        public Task<List<T>> ReadProducts();
        public Task WriteProduct(T t);
    }
}
