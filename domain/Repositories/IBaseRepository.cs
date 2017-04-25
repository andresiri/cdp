using System.Collections.Generic;

namespace domain.Repositories
{
    public interface IBaseRepository<T> where T: class
    {
        T Create(T obj);
        IEnumerable<T> GetAll();
    }
}