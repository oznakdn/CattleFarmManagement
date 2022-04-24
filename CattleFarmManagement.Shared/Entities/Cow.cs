using CattleFarmManagement.Shared.Abstract;
using CattleFarmManagement.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Entities
{
    public class Cow:BaseEntity,IEntity
    {
        public Cow()
        {
            Calvings = new HashSet<Calving>();
            CowPictures = new HashSet<CowPicture>();
            MilkRecords = new HashSet<MilkRecord>();
            Lactations = new HashSet<Lactation>();
            Seminations = new HashSet<Semination>();
        }



        public string Name { get; set; }
        public string TagNumber { get; set; }
        public double Age { get; set; }
        public short Weight { get; set; }



        public int? BorningId { get; set; }
        public Borning Borning { get; set; }

        public int? YieldId { get; set; }
        public Yield Yield { get; set; }



        public ICollection<Calving> Calvings { get; set; }
        public ICollection<CowPicture> CowPictures { get; set; }
        public ICollection<MilkRecord> MilkRecords { get; set; }
        public ICollection<Lactation> Lactations { get; set; }
        public ICollection<Semination> Seminations { get; set; }

    }
}
