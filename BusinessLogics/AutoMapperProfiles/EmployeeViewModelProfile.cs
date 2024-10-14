using AutoMapper;
using Menu.Data;
using Menu.Data.Dtos;

namespace Menu.BusinessLogics.AutoMapperProfiles
{
    public class EmployeeViewModelProfile : Profile
    {
        public EmployeeViewModelProfile()
        {
            CreateMap<EmployeeData, EmployeeViewModel>()
                .ForMember(d => d.EmployeeIdentityID, opt => opt.MapFrom(s => s.EmployeeID))
                .ForMember(d => d.Skill, opt => opt.MapFrom(s => s.SkillID)).ReverseMap();
        }
    }
}
