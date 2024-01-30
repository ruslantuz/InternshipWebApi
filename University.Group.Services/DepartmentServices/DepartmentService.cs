using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using University.Group.Models.Faculties;
using University.Group.Models.Groups;
using University.Group.Repositories;
using University.Group.Repositories.DepartmentsRepositories;
using University.Group.Repositories.GroupsRepositories;

namespace University.Group.Services.DepartmentServices
{
    public class DepartmentService : IService<DepartmentModel>
    {
        private readonly DepartmentRepository _departmentRepository;
        private readonly GroupRepository _groupRepository;
        private IMapper mapper;
        public DepartmentService()
        {
            _departmentRepository = new DepartmentRepository();
            _groupRepository = new GroupRepository();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DepartmentModel, DepartmentEntity>(MemberList.Destination).ReverseMap();  //.ForMember(x => x.Groups, opt => opt.Ignore());
                cfg.CreateMap<GroupModel, GroupEntity>(MemberList.Destination).ReverseMap();
                //cfg.CreateMap<GroupEntity, GroupModel>().ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department));

            });
            // only during development
            #if DEBUG
            configuration.AssertConfigurationIsValid();
            #endif
            mapper = configuration.CreateMapper();
        }
        public DepartmentService(DepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;

        }

        public void Add(DepartmentModel department)
        {
            DepartmentEntity departmentEntity = mapper.Map<DepartmentEntity>(department);
            _departmentRepository.Add(departmentEntity);
        }

        public DepartmentModel Get(int id)
        {
            DepartmentModel department = mapper.Map<DepartmentModel>(_departmentRepository.Get(id));
            
            List<GroupEntity> groupList = _groupRepository.GetAll();
            List<GroupModel> groupModelList = new List<GroupModel>();

            foreach (GroupEntity group in groupList)
            {
                if (group.DepartmentId == department.Id)
                {
                    GroupModel groupModel = mapper.Map<GroupModel>(group);
                    groupModelList.Add(groupModel);
                }
            }
            department.Groups = groupModelList;
            return department;
        }

        public List<DepartmentModel> GetAll()
        {
            List<DepartmentModel> departmentList = mapper.Map<List<DepartmentModel>>(_departmentRepository.GetAll());
            List<GroupEntity> groupList = _groupRepository.GetAll();

            List<GroupModel> groupModelList = new List<GroupModel>();

            foreach (DepartmentModel department in departmentList)
            {
                foreach (GroupEntity group in groupList)
                {
                    if (group.DepartmentId == department.Id)
                    {
                        GroupModel groupModel = mapper.Map<GroupModel>(group);
                        groupModelList.Add(groupModel);
                    }
                    department.Groups = groupModelList;
                }
            }
            return departmentList;
        }
    }
}
