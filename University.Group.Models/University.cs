using System.Collections.Generic;
using University.Group.Models.Faculties;

namespace University.Group.Models
{
    public sealed class University
    {
        public string Name { get; set; }
        public string Director { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }

        public University(string universityName)
        {
            Name = universityName;
        }
        public List<IDepartment> departments = new List<IDepartment>();

        public override string ToString()
        {
            return Name;
        }
    }
}
