using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Dtos.MilkRecordDtos
{
    public class DetailMilkRecordDto
    {
        public int Id { get; set; }
        public short RecordNumber { get; set; }
        public DateTime RecordDate { get; set; }
        public short Quantity { get; set; }
        public int CowId { get; set; }
        public string Description { get; set; }
    }
}
