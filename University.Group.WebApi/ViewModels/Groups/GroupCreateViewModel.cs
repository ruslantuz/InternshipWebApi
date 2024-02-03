using University.Group.Models.Groups;

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
