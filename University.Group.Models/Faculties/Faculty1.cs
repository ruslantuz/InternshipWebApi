using System.Collections.Generic;
using University.Group.Models.Groups;

namespace University.Group.Models.Faculties
{
    public sealed class Faculty1 : IFaculty
    {
        public IEnumerable<IGroup> GetGroups()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return "Faculty1";
        }
    }
}
