using System.Collections.Generic;
using University.Group.Models.Faculties;

namespace University.Group.Models
{
    public sealed class UniversityModel
    {
        public string Name { get; set; }
        public string Director { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public List<DepartmentModel> Departments { get; set; }
        
        public UniversityModel(string universityName, string director, string contactPhone, string email)
        {
            Name = universityName;
            Director = director;
            ContactPhone = contactPhone;
            Email = email;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
