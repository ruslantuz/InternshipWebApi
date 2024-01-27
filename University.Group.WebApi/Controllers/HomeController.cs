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
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {

        private readonly IService<GroupModel> _groupService;
        private readonly IService<DepartmentModel> _departmentService;
        public HomeController() { }

        //public HomeController(IService<GroupModel> groupService, IService<DepartmentModel> departmentService)
        //{
        //    groupService = _groupService;
        //    departmentService = _departmentService;
        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}
