using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.PersonalInfo.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.PersonalInfo.LastName))
            .ForMember(dest => dest.SalaryPerHour, opt => opt.MapFrom(src => src.SalaryPerHour.Value));
    }
    
}