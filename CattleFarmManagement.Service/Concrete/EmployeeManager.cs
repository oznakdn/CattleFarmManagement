using AutoMapper;
using CattleFarmManagement.Data.Repositories.Abstract.AbstractBase;
using CattleFarmManagement.Service.Abstract;
using CattleFarmManagement.Shared.Dtos.EmployeeDtos;
using CattleFarmManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Service.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region GetAll Async
        public async Task<List<ListEmployeesDto>> GetAll()
        {
            var employees = await _unitOfWork.Employee.GetAllAsync();
            return _mapper.Map<List<ListEmployeesDto>>(employees);
        }
        #endregion

        #region Get Detail
        public async Task<DetailEmployeeDto>GetDetail(int Id)
        {
            var employee = await _unitOfWork.Employee.GetAsync(x => x.ID == Id);
            return _mapper.Map<DetailEmployeeDto>(employee);
        }
        #endregion

        #region Get Contact
        public async Task<ContactEmployeeDto>GetContact(int contactId)
        {
            var contact = await _unitOfWork.EmployeeContact.GetAsync(x => x.ID == contactId);
            return _mapper.Map<ContactEmployeeDto>(contact);
        }

        #endregion


        #region Add With Contact
        public async Task AddWithContact(CreateEmployeeDto model)
        {
            var contact = new EmployeeContact
            {
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                IsActive = true,
                CreateDate = DateTime.Now,
                Description = model.Email
            };
            await _unitOfWork.EmployeeContact.AddAsync(contact);
            await _unitOfWork.SaveChangesAsync();

            var employee = new Employee
            {
                EmployeeContactId = contact.ID,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                GenderType = model.GenderType,
                BirthDate = model.BirthDate,
                Description = model.Description,
                CreateDate = DateTime.Now.Date,
                IsActive = true
            };

            var filePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"../CattleFarmManagement.Web.Mvc/wwwroot/pictures/employee"));
            var fileName = Path.Combine(filePath, model.pictureFile.FileName);
            var stream = new FileStream(fileName, FileMode.Create);
            await model.pictureFile.CopyToAsync(stream);
            employee.Picture = model.pictureFile.FileName;

            await _unitOfWork.Employee.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync();
        }
        #endregion



    }
}
