using AutoMapper;
using CattleFarmManagement.Shared.Dtos.LactationDtos;
using CattleFarmManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Service.Mappings.AutoMapper
{
    public class LactationProfile:Profile
    {
        public LactationProfile()
        {
            CreateMap<Lactation, ListLactationsDto>();
        }
    }
}
