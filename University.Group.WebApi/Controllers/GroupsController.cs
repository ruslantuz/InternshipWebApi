using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Group.Models.Faculties;
using University.Group.Models.Groups;
using University.Group.Services;
using University.Group.WebApi.ViewModels.Groups;

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
        [Route("update/{id:int}")]
        public IActionResult Update(int id)
        {
            GroupCreateViewModel editGroup = new GroupCreateViewModel();
            editGroup.Group = _groupService.Get(id);
            editGroup.DepartmentId = editGroup.Group.Department.Id;
            ViewBag.Departments = _departmentService.GetAll();
            return View(editGroup);
        }
        [Route("update/{id:int}")]
        [HttpPost]
        public RedirectToActionResult Update(GroupCreateViewModel groupUpdate)
        {
            GroupModel group = groupUpdate.Group;
            group.Department = _departmentService.Get(groupUpdate.DepartmentId);
            _groupService.Update(group);
            return RedirectToAction("Index");
        }
        [Route ("create")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = _departmentService.GetAll();
            return View();
        }
        [Route("create")]
        [HttpPost]
        public RedirectToActionResult Create(GroupCreateViewModel groupCreate)
        {
            GroupModel group = groupCreate.Group;
            group.Department = _departmentService.Get(groupCreate.DepartmentId);
            _groupService.Add(group);
            return RedirectToAction("Index");
        }
        [Route("[controller]/")]
        [HttpPost]
        public RedirectToActionResult Delete(int groupId)
        {
            GroupModel groupDelete = _groupService.Get(groupId);
            _groupService.Delete(groupDelete);
            return RedirectToAction("Index");
        }
    }
}
