using CattleFarmManagement.Shared.Dtos.BullDtos;
using CattleFarmManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Service.Abstract
{
    public interface IBullService
    {
        int Count();
        Task<List<ListBullsDto>> GetAll();
        Task<Bull> Get(Expression<Func<Bull, bool>> predicate);
        Task<DetailBullDto> GetWithPictures(int Id);

        Task Add(CreateBullDto createBullDto);
        Task Update(UpdateBullDto model);
    }
}
