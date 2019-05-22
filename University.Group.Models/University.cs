using University.Group.Models.Faculties;

namespace University.Group.Models
{
    public sealed class University
    {
        public Faculty1 Faculty1 { get; set; }

        public Faculty2 Faculty2 { get; set; }

        public override string ToString()
        {
            return "University Name";
        }
    }
}
