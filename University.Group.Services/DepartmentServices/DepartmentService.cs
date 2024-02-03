using AutoMapper;
using System.Collections.Generic;
using University.Group.Models.Faculties;
using University.Group.Models.Groups;
using University.Group.Repositories;

namespace University.Group.Services.DepartmentServices
{
    public class DepartmentService : IService<DepartmentModel>
    {
        private readonly IRepository<DepartmentEntity> _departmentRepository;
        private readonly IRepository<GroupEntity> _groupRepository;
        private readonly IMapper _mapper;
        
        public DepartmentService()
        {
        }
        
        public DepartmentService(IRepository<GroupEntity> groupRepository, IRepository<DepartmentEntity> departmentRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public void Add(DepartmentModel department)
        {
            DepartmentEntity departmentEntity = _mapper.Map<DepartmentEntity>(department);
            _departmentRepository.Add(departmentEntity);
        }

        public void Delete(DepartmentModel department)
        {
            DepartmentEntity departmentEntity = _mapper.Map<DepartmentEntity>(department);
            _departmentRepository.Delete(departmentEntity);

        }

        public DepartmentModel Get(int id)
        {
            DepartmentModel department = _mapper.Map<DepartmentModel>(_departmentRepository.Get(id));
            
            List<GroupEntity> groupList = _groupRepository.GetAll();
            List<GroupModel> groupModelList = new List<GroupModel>();

            foreach (GroupEntity group in groupList)
            {
                if (group.DepartmentId == department.Id)
                {
                    GroupModel groupModel = _mapper.Map<GroupModel>(group);
                    groupModelList.Add(groupModel);
                }
            }
            department.Groups = groupModelList;
            return department;
        }

        public List<DepartmentModel> GetAll()
        {
            List<DepartmentModel> departmentList = _mapper.Map<List<DepartmentModel>>(_departmentRepository.GetAll());
            List<GroupModel> groupModelList = _mapper.Map<List<GroupModel>>(_groupRepository.GetAll()); //new List<GroupModel>();
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
            DepartmentEntity departmentEntity = _mapper.Map<DepartmentEntity>(department);
            _departmentRepository.Update(departmentEntity);

        }
    }
}
