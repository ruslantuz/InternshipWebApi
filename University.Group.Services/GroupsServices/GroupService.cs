using System;
using System.Collections.Generic;
using System.Text;
using University.Group.Repositories;
using University.Group.Models;

namespace University.Group.Services.GroupsServices
{
    public class GroupService
    {
        private readonly IRepository<Models.Groups.Group> _groupRepository;

        public GroupService(IRepository<Models.Groups.Group> groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public void addGroup(Models.Groups.Group group)
        {
            _groupRepository.Add(group);
        }
    }
}
