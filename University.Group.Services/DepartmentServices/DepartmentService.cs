﻿using AutoMapper;
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
        public DepartmentService(AppDbContext dbContext)
        {
            _departmentRepository = new DepartmentRepository();
            _groupRepository = new GroupRepository(dbContext);
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DepartmentModel, DepartmentEntity>().ReverseMap().ForMember(x => x.Groups, opt => opt.Ignore());
                cfg.CreateMap<GroupModel, GroupEntity>().ForMember(x => x.DepartmentId, opt => opt.Ignore());
                cfg.CreateMap<GroupEntity, GroupModel>();

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

        public void AddDepartment(DepartmentModel department)
        {
            DepartmentEntity departmentEntity = mapper.Map<DepartmentEntity>(department);
            _departmentRepository.Add(departmentEntity);
        }

        public DepartmentModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<DepartmentModel> GetAll()
        {
            List<DepartmentModel> departmentList = mapper.Map<List<DepartmentModel>>(_departmentRepository.GetAll());
            List<GroupEntity> groupList = _groupRepository.GetAll();

            //var joinedData = from department in departmentList
            //                 join groupEntity in groupList on department.Id equals groupEntity.DepartmentId
            //                 select new { Department = department, GroupEntity = groupEntity };

            //var groupedData = joinedData.GroupBy(x => x.Department);

            //foreach (var department in groupedData)
            //{
            //    department.Key.Groups = department.Select(x => mapper.Map<IGroupModel>(x.GroupEntity)).ToList();
            //}

            List<IGroupModel> groupModelList = new List<IGroupModel>();

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
