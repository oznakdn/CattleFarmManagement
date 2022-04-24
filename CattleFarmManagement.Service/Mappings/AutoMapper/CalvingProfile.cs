using AutoMapper;
using CattleFarmManagement.Shared.Dtos.CalvingDtos;
using CattleFarmManagement.Shared.Entities;
using CattleFarmManagement.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Service.Mappings.AutoMapper
{
    public class CalvingProfile:Profile
    {
        public CalvingProfile()
        {
            CreateMap<Calving, ListCalvingsDto>()
                .ForMember(dest => dest.IsAlive, opt => opt.MapFrom(src => src.IsAlive == true ? "Yes" : "No"))
                .ForMember(dest => dest.BorningType, opt => opt.MapFrom(src => src.BorningType.ToString()))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()));
                
        }
    }
}
