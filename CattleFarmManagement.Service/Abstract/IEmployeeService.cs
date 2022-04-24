using CattleFarmManagement.Shared.Dtos.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Service.Abstract
{
    public interface IEmployeeService
    {
        Task<List<ListEmployeesDto>> GetAll();
        Task<DetailEmployeeDto> GetDetail(int Id);
        Task<ContactEmployeeDto> GetContact(int contactId);

        Task AddWithContact(CreateEmployeeDto model);
    }
}
