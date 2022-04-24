using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Dtos.EmployeeDtos
{
    public class DetailEmployeeDto
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string GenderType { get; set; }
        public string BirthDate { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }

    }
}
