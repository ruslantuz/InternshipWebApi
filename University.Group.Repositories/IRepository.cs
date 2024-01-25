using System;

namespace University.Group.Repositories
{
    public interface IRepository<T>
    {
        void Add(T model);
        void Update(T model);
        void Delete(T model);
        T Get(int id);
    }
}
