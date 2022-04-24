using CattleFarmManagement.Shared.Abstract;
using CattleFarmManagement.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Entities
{
    public class Yield:BaseEntity,IEntity
    {
        public short LactationCount { get; set; }
        public short AvarageLactationPeriod { get; set; }
        public short AvarageAllLactationYield { get; set; }
        public short AvarageDailyLactationYield { get; set; }

        public YieldType YieldType { get; set; }
       

    }
}
