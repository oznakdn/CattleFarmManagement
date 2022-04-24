using CattleFarmManagement.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Entities
{
    public class BullPicture:BaseEntity,IEntity
    {
        public string PictureName { get; set; }

        public int BullId { get; set; }
        public Bull Bull { get; set; }
    }
}
