using AutoMapper;
using University.Group.Models.Faculties;
using University.Group.Models.Groups;

namespace University.Group.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DepartmentModel, DepartmentEntity>(MemberList.Destination).ReverseMap();
            CreateMap<GroupModel, GroupEntity>(MemberList.Destination).ReverseMap();
        }
    }
}
