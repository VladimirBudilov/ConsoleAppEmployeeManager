using AutoMapper;
using Domain.Entities;
using Infrastructure.DataModels;

namespace Infrastructure.Mapping;

public class EmployeeDataModelProfile : Profile
{
    public EmployeeDataModelProfile()
    {
        CreateMap<Employee, EmployeeDataModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.PersonalInfo.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.PersonalInfo.LastName))
            .ForMember(dest => dest.SalaryPerHour, opt => opt.MapFrom(src => src.SalaryPerHour.Value))
            .ReverseMap();
  
    }
}