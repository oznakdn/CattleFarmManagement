using CattleFarmManagement.Shared.Abstract;
using CattleFarmManagement.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Entities
{
    public class Calving:BaseEntity,IEntity
    {

        public Calving()
        {
            CalvPictures = new HashSet<CalvPicture>();
        }

        public DateTime DryingDate { get; set; }
        public DateTime BirthDate { get; set; }
        public double DryingPeriod { get; set; }
        public GenderType Gender { get; set; }
        public bool IsAlive { get; set; }
        public short Weight { get; set; }
        public BorningType BorningType { get; set; }



        public int? CowId { get; set; }
        public Cow Cow { get; set; }


        public int? BullId { get; set; }
        public Bull Bull { get; set; }


        public ICollection<CalvPicture> CalvPictures { get; set; }

    }
}
