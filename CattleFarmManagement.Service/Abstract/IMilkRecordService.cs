using CattleFarmManagement.Shared.Dtos.MilkRecordDtos;
using CattleFarmManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Service.Abstract
{
    public interface IMilkRecordService
    {
        Task Add(CreateMilkRecordDto createMilkRecordDto);
        Task Update(UpdateMilkRecordDto updateMilkRecordDto);
        Task Delete(int Id);
        Task<List<ListMilkRecordsDto>> GetAll(int Id);
        Task<DetailMilkRecordDto> Get(int Id);
        Task<DetailMilkRecordDto> GetById(int Id);

        double Average(int Id);
    }
}
