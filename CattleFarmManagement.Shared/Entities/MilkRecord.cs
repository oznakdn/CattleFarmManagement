using CattleFarmManagement.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Entities
{
    public class MilkRecord:BaseEntity,IEntity
    {

        public short RecordNumber { get; set; }
        public DateTime RecordDate { get; set; }
        public short Quantity { get; set; }

        public int CowId { get; set; }
        public Cow Cow { get; set; }

    }
}
