using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeworkStructPattern.Repositories
{
    public interface IRepositoryProduct<T> : IRepository<T>
    {
        public Task WriteAllProducts(List<T> t);
    }
}
