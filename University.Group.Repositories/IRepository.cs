using System.Collections.Generic;

namespace University.Group.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(int id);
        List<T> GetAll();
    }
}
