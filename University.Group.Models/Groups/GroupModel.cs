using University.Group.Models.Faculties;

namespace University.Group.Models.Groups
{
    public class GroupModel : IGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MajorSubject { get; set; }
        public int Year { get; set; }
        public int StudentCount { get; set; }
        public DepartmentModel Department { get; set; }
        
        public GroupModel()
        {

        }
        
        public GroupModel(int groupId, string groupName, string major, int year, int count)
        {
            Id = groupId;
            Name = groupName;
            MajorSubject = major;
            Year = year;
            StudentCount = count;
        }
    }
}
