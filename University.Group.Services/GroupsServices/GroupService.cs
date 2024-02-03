using AutoMapper;
using System.Collections.Generic;
using University.Group.Models.Faculties;
using University.Group.Models.Groups;
using University.Group.Repositories;

namespace University.Group.Services.GroupsServices
{
    public class GroupService : IService<GroupModel>
    {
        private readonly IRepository<GroupEntity> _groupRepository;
        private readonly IRepository<DepartmentEntity> _departmentRepository;
        private readonly IMapper _mapper;

        public GroupService()
        {
        }

        public GroupService(IRepository<GroupEntity> groupRepository, IRepository<DepartmentEntity> departmentRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        
        public void Add(GroupModel group)
        {
            GroupEntity groupEntity = _mapper.Map<GroupEntity>(group);
            groupEntity.DepartmentId = group.Department.Id; 
            _groupRepository.Add(groupEntity);
        }

        public void Delete(GroupModel group)
        {
            GroupEntity groupEntity = _mapper.Map<GroupEntity>(group);
            groupEntity.DepartmentId = group.Department.Id;
            _groupRepository.Delete(groupEntity);
        }

        public GroupModel Get(int id)
        {
            GroupEntity groupEntity = _groupRepository.Get(id);
            GroupModel group = _mapper.Map<GroupModel>(groupEntity);
            group.Department = _mapper.Map<DepartmentModel>(_departmentRepository.Get(groupEntity.DepartmentId));
            return group;
        }

        public List<GroupModel> GetAll()
        {
            List<GroupEntity> groupEntityList = _groupRepository.GetAll();
            List<GroupModel> groupList = new List<GroupModel>();
            foreach (GroupEntity groupEntity in groupEntityList) {
                GroupModel group = _mapper.Map<GroupModel>(groupEntity);
                group.Department = _mapper.Map<DepartmentModel>(_departmentRepository.Get(groupEntity.DepartmentId));
                groupList.Add(group);
            };
            return groupList;
        }

        public void Update(GroupModel group)
        {
            GroupEntity groupEntity = _mapper.Map<GroupEntity>(group);
            groupEntity.DepartmentId = group.Department.Id;
            _groupRepository.Update(groupEntity);
        }
    }
}
