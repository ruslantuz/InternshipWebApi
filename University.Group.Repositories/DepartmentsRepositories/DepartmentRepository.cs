using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using University.Group.Models.Faculties;


namespace University.Group.Repositories.DepartmentsRepositories
{
    public class DepartmentRepository : IRepository<DepartmentEntity>
    {
        private readonly AppDbContext context;

        public DepartmentRepository()
        {
        }
        public DepartmentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(DepartmentEntity entity)
        {
            context.Departments.Add(entity);
            context.SaveChanges();
        }

        public void Delete(DepartmentEntity entity)
        {
            context.Departments.Remove(entity);
            context.SaveChanges();
        }

        public DepartmentEntity Get(int id)
        {
            return context.Departments.Find(id);
        }

        public List<DepartmentEntity> GetAll()
        {
            return context.Departments.ToList();
        }

        public void Update(DepartmentEntity entity)
        {
            var department = context.Departments.Attach(entity);
            department.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
