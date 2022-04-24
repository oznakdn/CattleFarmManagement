using AutoMapper;
using CattleFarmManagement.Shared.Dtos.CowDtos;
using CattleFarmManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Service.Mappings.AutoMapper
{
    public class CowProfile:Profile
    {
        public CowProfile()
        {
            CreateMap<Cow, ListCowsDto>();

            CreateMap<Cow, DetailCowDto>();

            CreateMap<CreateCowDto, Cow>();
            CreateMap<UpdateCowDto, Cow>();
        }
    }
}
