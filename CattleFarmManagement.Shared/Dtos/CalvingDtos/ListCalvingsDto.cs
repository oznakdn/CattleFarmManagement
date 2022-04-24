using CattleFarmManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Dtos.CalvingDtos
{
    public class ListCalvingsDto
    {

        public int ID { get; set; }
        public DateTime DryingDate { get; set; }
        public DateTime BirthDate { get; set; }
        public double DryingPeriod { get; set; }
        public string Gender { get; set; }
        public string IsAlive { get; set; }
        public short Weight { get; set; }
        public string BorningType { get; set; }

        public ICollection<CalvPicture> CalvPictures { get; set; }
        public Nullable<int> CowId { get; set; }
        public Nullable<int> BullId { get; set; }
      
    }
}
