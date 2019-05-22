using System.Collections.Generic;
using University.Group.Models.Groups;

namespace University.Group.Models.Faculties
{
    public interface IFaculty
    {
        IEnumerable<IGroup> GetGroups();
    }
}
