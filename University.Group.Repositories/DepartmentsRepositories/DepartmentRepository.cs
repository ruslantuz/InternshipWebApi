using System;
using System.Collections.Generic;
using System.Text;
using University.Group.Models.Faculties;

namespace University.Group.Repositories.DepartmentsRepositories
{
    public class DepartmentRepository : IRepository<DepartmentEntity>
    {
        //add db connection
        public void Add(DepartmentEntity entity)
        {
            // insert to db
            throw new NotImplementedException();
        }

        public void Delete(DepartmentEntity entity)
        {
            throw new NotImplementedException();
        }

        public DepartmentEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DepartmentEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(DepartmentEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
