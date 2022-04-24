using CattleFarmManagement.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Entities
{
    public class Lactation:BaseEntity,IEntity
    {
        public short LactationNumber { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime? FinishDate { get; set; }
        public double LactationDay { get; set; } // LactationDay= startdate + AddDay
        public double? TotalDay { get; set; }
        public short AvarageDailyMilking { get; set; }
        public short TotalMilking { get; set; }
        public bool IsDry { get; set; }


        public int? CowId { get; set; }
        public Cow Cow { get; set; }


      

    }
}
