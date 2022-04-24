using AutoMapper;
using CattleFarmManagement.Data.Repositories.Abstract.AbstractBase;
using CattleFarmManagement.Service.Abstract;
using CattleFarmManagement.Shared.Dtos.SeminationDtos;
using CattleFarmManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Service.Concrete
{
    public class SeminationManager : ISeminationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SeminationManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(CreateSeminationDto createSeminationDto)
        {
            var semination = new Semination
            {
                CowId=createSeminationDto.CowId,
                SeminationNumber=createSeminationDto.SeminationNumber,
                SeminationDate=createSeminationDto.SeminationDate,
                BullId=createSeminationDto.BullId,
                SpermNumber=createSeminationDto.SpermNumber,
                EmployeeId=createSeminationDto.EmployeeId,
                ControlDate=createSeminationDto.ControlDate,
                IsGravid=createSeminationDto.IsGravid,
                IsActive=true,
                CreateDate=DateTime.Now,
                Description=createSeminationDto.Description
            };
            await _unitOfWork.Semination.AddAsync(semination);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<GetSeminationDto> Get(int Id)
        {
            var semination = await _unitOfWork.Semination.GetAsync(x => x.ID == Id);
            return _mapper.Map<GetSeminationDto>(semination);
        }

        public async Task<List<ListSeminationsDto>> GetAll(int cowId)
        {
            var seminations =await _unitOfWork.Semination.GetAllAsync(x => x.CowId == cowId);
            return _mapper.Map<List<ListSeminationsDto>>(seminations);

        }

        public async Task Update(UpdateSeminationDto updateSeminationDto)
        {
            var semination = await _unitOfWork.Semination.GetAsync(x => x.ID == updateSeminationDto.ID);
            semination.SeminationNumber = updateSeminationDto.SeminationNumber;
            semination.SeminationDate = updateSeminationDto.SeminationDate;
            semination.BullId = updateSeminationDto.BullId;
            semination.SpermNumber = updateSeminationDto.SpermNumber;
            semination.EmployeeId = updateSeminationDto.EmployeeId;
            semination.ControlDate = updateSeminationDto.ControlDate;
            semination.IsGravid = updateSeminationDto.IsGravid;
            semination.Description = updateSeminationDto.Description;
            semination.IsActive = true;
            semination.UpdateDate = DateTime.Now;

            await _unitOfWork.Semination.UpdateAsync(semination);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
