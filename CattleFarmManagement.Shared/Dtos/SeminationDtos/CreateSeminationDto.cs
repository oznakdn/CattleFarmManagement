using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Dtos.SeminationDtos
{
    public class CreateSeminationDto
    {
        public int Id { get; set; }
        public short SeminationNumber { get; set; }
        public DateTime SeminationDate { get; set; }
        public Nullable<int> BullId { get; set; }
        public Nullable<int> SpermNumber { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<DateTime> ControlDate { get; set; }
        public bool IsGravid { get; set; }
        public string Description { get; set; }
        public int CowId { get; set; }
    }
}
