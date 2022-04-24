using AutoMapper;
using CattleFarmManagement.Data.Repositories.Abstract.AbstractBase;
using CattleFarmManagement.Service.Abstract;
using CattleFarmManagement.Shared.Dtos.LactationDtos;
using CattleFarmManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Service.Concrete
{
    public class LactationManager : ILactationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LactationManager(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Add Async
        public async Task Add(CreateLactationDto createLactationDto)
        {

            var lactation = new Lactation
            {
                CowId = createLactationDto.CowId,
                LactationNumber = createLactationDto.LactationNumber,
                StartDate = createLactationDto.StartDate,
                FinishDate = createLactationDto.FinishDate,
                LactationDay = createLactationDto.LactationDay,
                TotalDay = TotalDay(createLactationDto.StartDate, createLactationDto.FinishDate),
                TotalMilking = createLactationDto.TotalMilking,
                AvarageDailyMilking = createLactationDto.AvarageDailyMilking,
                IsDry = createLactationDto.IsDry,
                CreateDate = DateTime.Now.Date,
                Description = createLactationDto.Description,
                IsActive = true
            };

            await _unitOfWork.Lactation.AddAsync(lactation);
            await _unitOfWork.SaveChangesAsync();

        }
        #endregion

        #region GetAll Async
        public async Task<List<ListLactationsDto>> GetAll(int Id)
        {
            var lactations = await _unitOfWork.Lactation.GetAllAsync(x => x.CowId == Id);
            var model = _mapper.Map<List<ListLactationsDto>>(lactations);
            return model;
        }
        #endregion

        #region Total Day
        public double TotalDay(DateTime startDate, DateTime? finishDate)
        {
            TimeSpan timeSpan;
            if (finishDate is null)
            {
                timeSpan = DateTime.Now - startDate;
                return timeSpan.TotalDays;
            }
            else
            {
                timeSpan = startDate - finishDate.Value;
                return timeSpan.TotalDays;
            }

        }
        #endregion



    }
}
