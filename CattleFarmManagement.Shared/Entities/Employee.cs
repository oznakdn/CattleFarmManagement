using CattleFarmManagement.Shared.Abstract;
using CattleFarmManagement.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Entities
{
    public class Employee:BaseEntity,IEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public GenderType GenderType { get; set; }
        public DateTime BirthDate { get; set; }
        public string Picture { get; set; }

        public int EmployeeContactId { get; set; }
        public EmployeeContact EmployeeContact { get; set; }
    }
}
