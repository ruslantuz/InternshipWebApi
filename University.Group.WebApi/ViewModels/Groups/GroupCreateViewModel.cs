using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Group.Models.Faculties;
using University.Group.Models.Groups;
using University.Group.Services.DepartmentServices;

namespace University.Group.WebApi.ViewModels.Groups
{

    public class GroupCreateViewModel
    {
        public GroupModel Group { get; set; }
        public int DepartmentId { get; set; }
        public GroupCreateViewModel()
        {
        }
    }
}
