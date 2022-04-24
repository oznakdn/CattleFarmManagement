using AutoMapper;
using CattleFarmManagement.Shared.Dtos.SeminationDtos;
using CattleFarmManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Service.Mappings.AutoMapper
{
    public class SeminationProfile:Profile
    {
        public SeminationProfile()
        {
            CreateMap<Semination, ListSeminationsDto>()
                .ForMember(dest => dest.IsGravid, opt => opt.MapFrom(src => src.IsGravid == true ? "Yes" : "No"))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ID));

            CreateMap<Semination, GetSeminationDto>();
        }
    }
}
