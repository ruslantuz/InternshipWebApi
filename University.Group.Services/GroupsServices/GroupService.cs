using System;
using System.Collections.Generic;
using System.Text;
using University.Group.Models.Groups;
using AutoMapper;
using University.Group.Repositories.GroupsRepositories;
using University.Group.Models.Faculties;

namespace University.Group.Services.GroupsServices
{
    public class GroupService : IService<GroupModel>
    {
        private readonly GroupRepository _groupRepository;
        private IMapper mapper; // move to startup
        public GroupService()
        {
                
        }
        public GroupService(GroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public void AddGroup(GroupModel group, DepartmentModel department)
        {
            GroupEntity groupEntity = mapper.Map<GroupEntity>(group);
            groupEntity.DepartmentId = department.Id; 
            _groupRepository.Add(groupEntity);
        }

        public IEnumerable<GroupModel> GetAll()
        {
            IEnumerable<GroupModel> groupList = mapper.Map<IEnumerable<GroupModel>>(_groupRepository.GetAll());
            return groupList;
        }
    }
}
