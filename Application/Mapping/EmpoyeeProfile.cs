﻿using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class EmpoyeeProfile : Profile
{
    public EmpoyeeProfile()
    {
        CreateMap<Employee, EmployeeDto>();
    }
    
}