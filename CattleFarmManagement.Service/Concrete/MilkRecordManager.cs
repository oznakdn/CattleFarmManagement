using AutoMapper;
using CattleFarmManagement.Data.Repositories.Abstract.AbstractBase;
using CattleFarmManagement.Service.Abstract;
using CattleFarmManagement.Shared.Dtos.MilkRecordDtos;
using CattleFarmManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Service.Concrete
{
    public class MilkRecordManager : IMilkRecordService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MilkRecordManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        #region Add Async
        public async Task Add(CreateMilkRecordDto createMilkRecordDto)
        {
            var milkRecord = new MilkRecord
            {
                CowId = createMilkRecordDto.CowId,
                RecordNumber = createMilkRecordDto.RecordNumber,
                RecordDate = createMilkRecordDto.RecordDate,
                Quantity = createMilkRecordDto.Quantity,
                Description = createMilkRecordDto.Description,
                CreateDate = DateTime.Now,
                IsActive = true
            };
            await _unitOfWork.MilkRecord.AddAsync(milkRecord);
            await _unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Update Async
        public async Task Update(UpdateMilkRecordDto updateMilkRecordDto)
        {
            var milkRecord = await _unitOfWork.MilkRecord.GetAsync(x => x.ID == updateMilkRecordDto.Id);

            milkRecord.RecordNumber = updateMilkRecordDto.RecordNumber;
            milkRecord.RecordDate = updateMilkRecordDto.RecordDate;
            milkRecord.Quantity = updateMilkRecordDto.Quantity;
            milkRecord.Description = updateMilkRecordDto.Description;
            milkRecord.UpdateDate = DateTime.Now;
            milkRecord.IsActive = true;

            await _unitOfWork.MilkRecord.UpdateAsync(milkRecord);
            await _unitOfWork.SaveChangesAsync();
        }
        #endregion

        #region Delete Async
        public async Task Delete(int Id)
        {
            await _unitOfWork.MilkRecord.DeleteAsync(Id);
            await _unitOfWork.SaveChangesAsync();
        }
        #endregion


        #region Average
        public double Average(int Id)
        {
            return _unitOfWork.MilkRecord.Average(Id);
        }
        #endregion

        #region GetAll Async
        public async Task<List<ListMilkRecordsDto>> GetAll(int Id)
        {
            var milkRecors = await _unitOfWork.MilkRecord.GetAllAsync(x => x.CowId == Id);
            return _mapper.Map<List<ListMilkRecordsDto>>(milkRecors);

        }
        #endregion

        #region Get Async
        public async Task<DetailMilkRecordDto> Get(int Id)
        {
            var record = await _unitOfWork.MilkRecord.GetAsync(x => x.CowId == Id);
            return _mapper.Map<DetailMilkRecordDto>(record);
        }
        #endregion

        #region GetById Async
        public async Task<DetailMilkRecordDto> GetById(int Id)
        {
            var milkRecord = await _unitOfWork.MilkRecord.GetAsync(x => x.ID == Id);
            return _mapper.Map<DetailMilkRecordDto>(milkRecord);

        }
        #endregion



    }
}
