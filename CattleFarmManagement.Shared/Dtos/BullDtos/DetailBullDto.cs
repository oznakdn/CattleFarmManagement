using CattleFarmManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Dtos.BullDtos
{
    public class DetailBullDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string TagNumber { get; set; }
        public double Age { get; set; }
        public short Weight { get; set; }
        public string Description { get; set; }
        public ICollection<BullPicture> BullPictures { get; set; }
    }
}
