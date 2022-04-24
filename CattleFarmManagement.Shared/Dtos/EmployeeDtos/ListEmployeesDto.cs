using CattleFarmManagement.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Dtos.EmployeeDtos
{
    public class ListEmployeesDto
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public int EmployeeContactId { get; set; }
    }
}
