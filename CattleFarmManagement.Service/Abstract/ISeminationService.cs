using CattleFarmManagement.Shared.Dtos.SeminationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Service.Abstract
{
    public interface ISeminationService
    {
        Task<List<ListSeminationsDto>> GetAll(int cowId);

        Task<GetSeminationDto> Get(int Id);
        Task Update(UpdateSeminationDto updateSeminationDto);
        Task Add(CreateSeminationDto createSeminationDto);
  
    }
}
