using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Group.Models.Faculties;
using University.Group.Models.Groups;
using University.Group.Services;

namespace University.Group.WebApi.Controllers
{
    [Route ("[controller]")]
    public class DepartmentsController : Controller
    {
        private readonly IService<GroupModel> _groupService;
        private readonly IService<DepartmentModel> _departmentService;
        public DepartmentsController(IService<GroupModel> groupService, IService<DepartmentModel> departmentService)
        {
            _groupService = groupService;
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            List<DepartmentModel> departmentList = _departmentService.GetAll();
            return View(departmentList);
        }
    }
}
