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
        private readonly IMapper mapper;
        public DepartmentService()
        {
            _departmentRepository = new DepartmentRepository();
            _groupRepository = new GroupRepository();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DepartmentModel, DepartmentEntity>(MemberList.Destination).ReverseMap();
                cfg.CreateMap<GroupModel, GroupEntity>(MemberList.Destination).ReverseMap();
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

        public void Delete(DepartmentModel department)
        {
            DepartmentEntity departmentEntity = mapper.Map<DepartmentEntity>(department);
            _departmentRepository.Delete(departmentEntity);

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
            List<GroupModel> groupModelList = mapper.Map<List<GroupModel>>(_groupRepository.GetAll()); //new List<GroupModel>();
            foreach (DepartmentModel department in departmentList)
            {
                foreach (GroupModel group in groupModelList)
                {
                    if (group.Department.Id == department.Id)
                    {
                        department.Groups.Add(group);
                    }
                }
            }
            return departmentList;
        }

        public void Update(DepartmentModel department)
        {
            DepartmentEntity departmentEntity = mapper.Map<DepartmentEntity>(department);
            _departmentRepository.Update(departmentEntity);

        }
    }
}
