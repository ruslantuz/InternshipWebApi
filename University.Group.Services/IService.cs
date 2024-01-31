using System;
using System.Collections.Generic;

namespace University.Group.Services
{
    public interface IService<T>
    {
        void Add(T entity) { }
        void Update(T entity);
        void Delete(T entity);
        T Get(int id);
        List<T> GetAll();
    }
}
