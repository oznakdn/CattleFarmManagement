using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Dtos.SeminationDtos
{
    public class ListSeminationsDto
    {
        public int Id { get; set; }
        public short SeminationNumber { get; set; }
        public DateTime SeminationDate { get; set; }
        public int? BullId { get; set; }
        public int? SpermNumber { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? ControlDate { get; set; }
        public string IsGravid { get; set; }
        public string Description { get; set; }


        public int CowId { get; set; }
    }
}
