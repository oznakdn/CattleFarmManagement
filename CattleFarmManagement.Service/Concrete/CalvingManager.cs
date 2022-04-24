using AutoMapper;
using CattleFarmManagement.Data.Repositories.Abstract.AbstractBase;
using CattleFarmManagement.Service.Abstract;
using CattleFarmManagement.Shared.Dtos.CalvingDtos;
using CattleFarmManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Service.Concrete
{
    public class CalvingManager : ICalvingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CalvingManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        #region Add Async
        public async Task Add(CreateCalvingDto model)
        {
            var calving = new Calving
            {
                CowId = model.CowId,
                DryingDate = model.DryingDate,
                BirthDate = model.BirthDate,
                DryingPeriod = DryPeriod(model.DryingDate, model.BirthDate),
                Gender = model.Gender,
                IsAlive = model.IsAlive,
                Weight = model.Weight,
                BorningType = model.BorningType,
                BullId = model.BullId,
                Description=model.Description,
                CreateDate=DateTime.Now.Date
            };

            var filePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"../CattleFarmManagement.Web.Mvc/wwwroot/pictures/calv"));
            foreach (var item in model.pictureFiles)
            {
                var fileName = Path.Combine(filePath, item.FileName);
                var stream = new FileStream(fileName, FileMode.Create);
                await item.CopyToAsync(stream);

                calving.CalvPictures.Add
                    (
                        new CalvPicture 
                        { 
                            PictureName = item.FileName, 
                            IsActive = true, 
                            Description = item.FileName, 
                            CreateDate = DateTime.Now,
                        }
                    
                    );
            }

            await _unitOfWork.Calving.AddAsync(calving);
            await _unitOfWork.SaveChangesAsync();


        }
        #endregion

        #region GetAll Async
        public async Task<List<ListCalvingsDto>> GetAll(int cowId)
        {
            var calvings = await _unitOfWork.Calving.GetAllWithIncludeAsync(x => x.CowId == cowId, y => y.CalvPictures);
            return _mapper.Map<List<ListCalvingsDto>>(calvings);
        }
        #endregion

        #region DryPeriod
        public double DryPeriod(DateTime dryingDate, DateTime birthDate)
        {
            TimeSpan timeSpan = birthDate - dryingDate;
            return timeSpan.TotalDays;
        }
        #endregion


    }
}
