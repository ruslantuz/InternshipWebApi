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
    [Route("[controller]")]
    public class GroupsController : Controller
    {
        private readonly IService<GroupModel> _groupService;
        private readonly IService<DepartmentModel> _departmentService;
        public GroupsController(IService<GroupModel> groupService, IService<DepartmentModel> departmentService)
        {
            _groupService = groupService;
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            List<GroupModel> groupList = _groupService.GetAll();
            return View(groupList);
        }
        [HttpGet("{id:int}")]
        public IActionResult GroupInfo(int id)
        {
            GroupModel group = _groupService.Get(id); //do try catch for invalid id
            List<GroupModel> groupList = new List<GroupModel>();
            groupList.Add(group);

            return View("~/Views/Groups/Index.cshtml", groupList);
        }

        [Route ("create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(GroupModel group)
        {
            _groupService.Add(group);
            return RedirectToAction("GroupInfo", group.Id);
        }
    }
}
