using System;
using System.Collections.Generic;
using System.Text;

namespace University.Group.Models
{
    public class UniversityEntity
    {
        public string Name { get; set; }
        public string Director { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public UniversityEntity(string universityName, string director, string contactPhone, string email)
        {
            Name = universityName;
            Director = director;
            ContactPhone = contactPhone;
            Email = email;
        }
    }
}
