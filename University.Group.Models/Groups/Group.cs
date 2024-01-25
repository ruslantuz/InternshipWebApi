using System;
using System.Collections.Generic;
using System.Text;

namespace University.Group.Models.Groups
{
    public class Group : IGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MajorSubject { get; set; }
        public int Year { get; set; }
        public int StudentCount { get; set; }
        public Group(int groupId, string groupName, string major, int year, int count)
        {
            Id = groupId;
            Name = groupName;
            MajorSubject = major;
            Year = year;
            StudentCount = count;
        }
        public IGroup GetGroupInfo()
        {
            throw new NotImplementedException();
        }
    }
}
