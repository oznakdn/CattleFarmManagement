using CattleFarmManagement.Shared.Dtos.LactationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Service.Abstract
{
    public interface ILactationService
    {
        Task<List<ListLactationsDto>> GetAll(int Id);
        Task Add(CreateLactationDto createLactationDto);
    }
}
