using CattleFarmManagement.Shared.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Dtos.EmployeeDtos
{
    public class CreateEmployeeDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public GenderType GenderType { get; set; }
        public DateTime BirthDate { get; set; }
        public IFormFile pictureFile { get; set; }

        //public int ContactId { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

    }
}
