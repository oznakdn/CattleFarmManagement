using AutoMapper;
using CattleFarmManagement.Shared.Dtos.MilkRecordDtos;
using CattleFarmManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Service.Mappings.AutoMapper
{
    public class MilkRecordProfile:Profile
    {
        public MilkRecordProfile()
        {
            CreateMap<MilkRecord, ListMilkRecordsDto>();
            CreateMap<MilkRecord, DetailMilkRecordDto>();
        }
    }
}
