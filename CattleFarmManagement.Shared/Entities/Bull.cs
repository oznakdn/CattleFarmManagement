using CattleFarmManagement.Shared.Abstract;
using CattleFarmManagement.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Entities
{
    public class Bull:BaseEntity,IEntity
    {


        public Bull()
        {
            Calvings = new HashSet<Calving>();
            BullPictures = new HashSet<BullPicture>();
        }



        public string Name { get; set; }
        public string TagNumber { get; set; }
        public double Age { get; set; }
        public short Weight { get; set; }

        public int? BorningId { get; set; }

        public ICollection<Calving> Calvings { get; set; }
        public ICollection<BullPicture> BullPictures { get; set; }
    }
}
