using System;
using System.Collections.Generic;
using System.Text;
using University.Group.Models.Groups;
using AutoMapper;
using University.Group.Repositories.GroupsRepositories;
using University.Group.Models.Faculties;
using University.Group.Repositories;
using University.Group.Repositories.DepartmentsRepositories;

namespace University.Group.Services.GroupsServices
{
    public class GroupService : IService<GroupModel>
    {
        private readonly GroupRepository _groupRepository;
        private readonly DepartmentRepository _departmentRepository;
        private readonly IMapper mapper;
        public GroupService()
        {
            _groupRepository = new GroupRepository();
            _departmentRepository = new DepartmentRepository();
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

        public void Delete(GroupModel group)
        {
            GroupEntity groupEntity = mapper.Map<GroupEntity>(group);
            groupEntity.DepartmentId = group.Department.Id;
            _groupRepository.Delete(groupEntity);
        }

        public GroupModel Get(int id)
        {
            GroupEntity groupEntity = _groupRepository.Get(id);
            GroupModel group = mapper.Map<GroupModel>(groupEntity);
            group.Department = mapper.Map<DepartmentModel>(_departmentRepository.Get(groupEntity.DepartmentId));
            return group;
        }

        public List<GroupModel> GetAll()
        {
            List<GroupEntity> groupEntityList = _groupRepository.GetAll();
            List<GroupModel> groupList = new List<GroupModel>();
            foreach (GroupEntity groupEntity in groupEntityList) {
                GroupModel group = mapper.Map<GroupModel>(groupEntity);
                group.Department = mapper.Map<DepartmentModel>(_departmentRepository.Get(groupEntity.DepartmentId));
                groupList.Add(group);
            };
            return groupList;
        }
    }
}
