using System;
using System.Collections.Generic;
using System.Text;
using University.Group.Models.Faculties;
using University.Group.Repositories;

namespace University.Group.Services.DepartmentServices
{
    class DepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentService(IRepository<Department> department)
        {
            _departmentRepository = department;
        }
        public void addDepartment(Department department)
        {
            _departmentRepository.Add(department);
        }
    }
}
