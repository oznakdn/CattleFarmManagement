using CattleFarmManagement.Shared.Dtos.CalvingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Service.Abstract
{
    public interface ICalvingService
    {
        Task<List<ListCalvingsDto>> GetAll(int cowId);
        Task Add(CreateCalvingDto model);
    }
}
