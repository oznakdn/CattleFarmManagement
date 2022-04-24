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
    public class EmployeeContactProfile:Profile
    {
        public EmployeeContactProfile()
        {
            CreateMap<EmployeeContact, ContactEmployeeDto>();
        }
    }
}
