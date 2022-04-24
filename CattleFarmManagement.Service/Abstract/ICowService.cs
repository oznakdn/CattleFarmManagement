using CattleFarmManagement.Shared.Dtos.CowDtos;
using CattleFarmManagement.Shared.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Service.Abstract
{
    public interface ICowService
    {

        #region Queries
        Task<List<ListCowsDto>> GetAllAsync(Expression<Func<Cow, bool>> predicate = null);
        List<ListCowsDto> GetAll();
        Task<DetailCowDto> GetById(int Id);
        Task<Cow> Get(Expression<Func<Cow, bool>> predicate);

        int Count();

        #endregion

        #region Commands
        Task Add(CreateCowDto createCowDto);
        Task Update(UpdateCowDto model);

        #endregion



    }
}
