using AutoMapper;
using CattleFarmManagement.Data.Repositories.Abstract.AbstractBase;
using CattleFarmManagement.Service.Abstract;
using CattleFarmManagement.Shared.Dtos.CowDtos;
using CattleFarmManagement.Shared.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace CattleFarmManagement.Service.Concrete
{
    public class CowManager : ICowService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CowManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Count
        public int Count()
        {
            return _unitOfWork.Cow.Count();
        }
        #endregion

        #region GetAll With Include Async
        public async Task<List<ListCowsDto>> GetAllAsync(Expression<Func<Cow, bool>> predicate = null)
        {
            var cows = await _unitOfWork.Cow.GetAllWithIncludeAsync(x => x.IsActive, x => x.CowPictures);
            if (cows.Count > 0)
            {
                return _mapper.Map<List<ListCowsDto>>(cows);

            }

            throw new InvalidOperationException("There is no Cow");
        }
        #endregion

        #region GetAll
        public List<ListCowsDto> GetAll()
        {
            var cows = _unitOfWork.Cow.GetAll();
            return _mapper.Map<List<ListCowsDto>>(cows);

        }
        #endregion

        #region Get Async
        public async Task<Cow> Get(Expression<Func<Cow, bool>> predicate)
        {
            return await _unitOfWork.Cow.GetAsync(predicate);
        }
        #endregion

        #region GetById Async
        public async Task<DetailCowDto> GetById(int Id)
        {
            var cow = await _unitOfWork.Cow.GetWithIncludeAsync(x => x.ID == Id, x => x.CowPictures);
            if (cow != null)
            {
                var model= _mapper.Map<DetailCowDto>(cow);
                return model;
            }

            throw new InvalidOperationException($"There is no {Id} ID Cow");
        }
        #endregion

        #region Add Async
        public async Task Add(CreateCowDto createCowDto)
        {

            var cow = new Cow
            {
                Name = createCowDto.Name,
                TagNumber = createCowDto.TagNumber,
                Age = createCowDto.Age,
                Weight = createCowDto.Weight,
                Description = createCowDto.Description,
                IsActive = createCowDto.IsActive,
                CreateDate = DateTime.Now.Date,
            };

            var filePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"../CattleFarmManagement.Web.Mvc/wwwroot/pictures/cow"));
            foreach (var item in createCowDto.picturFiles)
            {
                var fileName = Path.Combine(filePath, item.FileName);
                var stream = new FileStream(fileName, FileMode.Create);
                await item.CopyToAsync(stream);
                cow.CowPictures.Add
                (
                    new CowPicture
                    {
                        PictureName = item.FileName,
                        CreateDate = DateTime.Now,
                        IsActive = true,
                        Description = createCowDto.TagNumber
                    }
                );

            }

            await _unitOfWork.Cow.AddAsync(cow);
            await _unitOfWork.SaveChangesAsync();

        }

        #endregion

        #region Update Async

        public async Task Update(UpdateCowDto model)
        {
            var cow = await _unitOfWork.Cow.GetAsync(x => x.ID == model.ID);
            cow.Name = model.Name;
            cow.TagNumber = model.TagNumber;
            cow.Age = model.Age;
            cow.Weight = model.Weight;
            cow.Description = model.Description;
            cow.IsActive = model.IsActive;
            cow.UpdateDate = DateTime.Now.Date;
            await _unitOfWork.Cow.UpdateAsync(cow);
            await _unitOfWork.SaveChangesAsync();
        }
        #endregion


    }
}
