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
        public GroupService(AppDbContext dbContext)
        {
            _groupRepository = new GroupRepository(dbContext);
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DepartmentModel, DepartmentEntity>().ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.Groups)).ReverseMap();//.ForMember(x => x.Groups, opt => opt.Ignore());
                cfg.CreateMap<GroupModel, GroupEntity>().ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.Department.Id)).ReverseMap();
                
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
            //groupEntity.Department.Id = department.Id; 
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
