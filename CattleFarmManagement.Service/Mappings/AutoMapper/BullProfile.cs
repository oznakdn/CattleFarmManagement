using AutoMapper;
using CattleFarmManagement.Shared.Dtos.BullDtos;
using CattleFarmManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Service.Mappings.AutoMapper
{
    public class BullProfile:Profile
    {
        public BullProfile()
        {
            CreateMap<Bull, ListBullsDto>();
            CreateMap<Bull, DetailBullDto>();
            CreateMap<CreateBullDto, Bull>();
        }
    }
}
