using AutoMapper;
using CattleFarmManagement.Shared.Dtos.EmployeeDtos;
using CattleFarmManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Service.Mappings.AutoMapper
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, ListEmployeesDto>();
            //.ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.GenderType.ToString()));

            CreateMap<Employee, DetailEmployeeDto>()
                .ForMember(dest => dest.GenderType, opt => opt.MapFrom(src => src.GenderType.ToString()))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToShortDateString()));
        }
    }
}
