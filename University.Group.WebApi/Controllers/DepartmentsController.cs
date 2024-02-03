using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        
        [Route("update/{id:int}")]
        public IActionResult Update(int id)
        {
            DepartmentModel editDepartment = _departmentService.Get(id);
            return View(editDepartment);
        }
        
        [Route("update/{id:int}")]
        [HttpPost]
        public RedirectToActionResult Update(DepartmentModel departmentUpdate)
        {
            DepartmentModel department = departmentUpdate;
            _departmentService.Update(department);
            return RedirectToAction("Index");
        }
        
        [Route("create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [Route("create")]
        [HttpPost]
        public RedirectToActionResult Create(DepartmentModel departmentCreate)
        {
            _departmentService.Add(departmentCreate);
            return RedirectToAction("Index");
        }
        
        [Route("")]
        [HttpPost]
        public RedirectToActionResult Delete(int departmentId)
        {
            DepartmentModel departmentDelete = _departmentService.Get(departmentId);
            _departmentService.Delete(departmentDelete);
            return RedirectToAction("Index");
        }
    }
}
