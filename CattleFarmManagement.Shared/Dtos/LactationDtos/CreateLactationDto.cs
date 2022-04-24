using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Dtos.LactationDtos
{
    public class CreateLactationDto
    {

        public short LactationNumber { get; set; }
        public DateTime StartDate { get; set; }
        public Nullable<DateTime> FinishDate { get; set; }
        public double LactationDay { get; set; } // LactationDay= startdate + AddDay
        public double? TotalDay { get; set; }
        public short AvarageDailyMilking { get; set; }
        public short TotalMilking { get; set; }
        public bool IsDry { get; set; }
        public Nullable<int> CowId { get; set; }
        public string Description { get; set; }
    }
}
