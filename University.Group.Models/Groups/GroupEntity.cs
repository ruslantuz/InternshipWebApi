using System;
using System.Collections.Generic;
using System.Text;

namespace University.Group.Models.Groups
{
    public class GroupEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MajorSubject { get; set; }
        public int Year { get; set; }
        public int StudentCount { get; set; }
        public int DepartmentId { get; set; }
        public GroupEntity(int groupId, string groupName, string major, int year, int count, int departmentId)
        {
            Id = groupId;
            Name = groupName;
            MajorSubject = major;
            Year = year;
            StudentCount = count;
            DepartmentId = departmentId;
        }
    }
}
