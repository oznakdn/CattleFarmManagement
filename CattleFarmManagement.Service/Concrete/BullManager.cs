using AutoMapper;
using CattleFarmManagement.Data.Repositories.Abstract.AbstractBase;
using CattleFarmManagement.Service.Abstract;
using CattleFarmManagement.Shared.Dtos.BullDtos;
using CattleFarmManagement.Shared.Entities;
using System.Linq.Expressions;

namespace CattleFarmManagement.Service.Concrete
{
    public class BullManager : IBullService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BullManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Count
        public int Count()
        {
            return _unitOfWork.Bull.Count();
        }
        #endregion

        #region GetAll Async
        public async Task<List<ListBullsDto>> GetAll()
        {
            var bulls = await _unitOfWork.Bull.GetAllWithIncludeAsync(null,x => x.BullPictures);
            return _mapper.Map<List<ListBullsDto>>(bulls);
        }
        #endregion

        #region Get Async
        public async Task<Bull> Get(Expression<Func<Bull, bool>> predicate)
        {
            return await _unitOfWork.Bull.GetAsync(predicate);
        }
        #endregion

        #region Get With Include
        public async Task<DetailBullDto>GetWithPictures(int Id)
        {
            var bull = await _unitOfWork.Bull.GetWithIncludeAsync(x => x.ID == Id, y => y.BullPictures);
            return _mapper.Map<DetailBullDto>(bull);
        }
        #endregion

        #region Add Async
        public async Task Add(CreateBullDto createBullDto)
        {
            var bull=_mapper.Map<Bull>(createBullDto);
            bull.CreateDate = DateTime.Now.Date;

            var filePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"../CattleFarmManagement.Web.Mvc/wwwroot/pictures/bull"));
            foreach (var item in createBullDto.pictureFiles)
            {
                var fileName = Path.Combine(filePath, item.FileName);
                var stream = new FileStream(fileName, FileMode.Create);
                await item.CopyToAsync(stream);

                bull.BullPictures.Add(new BullPicture { PictureName = item.FileName,IsActive=true,CreateDate=DateTime.Now,Description=bull.TagNumber});

            }

            await _unitOfWork.Bull.AddAsync(bull);
            await _unitOfWork.SaveChangesAsync();
        }

        #endregion

        #region Update Async
        public async Task Update(UpdateBullDto model)
        {
            var bull = await _unitOfWork.Bull.GetAsync(x => x.ID == model.ID);
            bull.Name = model.Name;
            bull.TagNumber = model.TagNumber;
            bull.Age = model.Age;
            bull.Weight = model.Weight;
            bull.Description = model.Description;
            bull.UpdateDate = DateTime.Now;

            await _unitOfWork.Bull.UpdateAsync(bull);
            await _unitOfWork.SaveChangesAsync();
        }

        
        #endregion


    }
}
