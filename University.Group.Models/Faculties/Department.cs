using System.Collections.Generic;
using University.Group.Models.Groups;

namespace University.Group.Models.Faculties
{
    public sealed class Department : IDepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Head { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public List<IGroup> groups = new List<IGroup>();
        public Department(int id, string name, string head, string phone, string email)
        {
            Id = id;
            Name = name;
            Head = head;
            Phone = phone;
            Email = email;
        }
        public IEnumerable<IGroup> GetGroups()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
