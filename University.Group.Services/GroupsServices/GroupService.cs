using System;
using System.Collections.Generic;
using System.Text;
using University.Group.Models.Groups;
using AutoMapper;
using University.Group.Repositories.GroupsRepositories;
using University.Group.Models.Faculties;
using University.Group.Repositories;


namespace University.Group.Services.GroupsServices
{
    public class GroupService : IService<GroupModel>
    {
        private readonly GroupRepository _groupRepository;
        private IMapper mapper;
        public GroupService()
        {
            _groupRepository = new GroupRepository();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DepartmentModel, DepartmentEntity>(MemberList.Destination).ReverseMap();
                cfg.CreateMap<GroupModel, GroupEntity>(MemberList.Destination).ReverseMap();

            });
            
            #if DEBUG
            configuration.AssertConfigurationIsValid();
            #endif
            mapper = configuration.CreateMapper();
        }
        public GroupService(GroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public void Add(GroupModel group)//, DepartmentModel department)
        {
            GroupEntity groupEntity = mapper.Map<GroupEntity>(group);
            groupEntity.DepartmentId = group.Department.Id; 
            _groupRepository.Add(groupEntity);
        }


        public GroupModel Get(int id)
        {
            GroupModel group = mapper.Map<GroupModel>(_groupRepository.Get(id));
            return group;
        }

        public List<GroupModel> GetAll()
        {
            List<GroupEntity> groupEntityList = _groupRepository.GetAll();
            List<GroupModel> groupList = new List<GroupModel>();
            foreach (GroupEntity groupEntity in groupEntityList) {
                groupList.Add(mapper.Map<GroupModel>(groupEntity));
            };
            return groupList;
        }
    }
}
