using CattleFarmManagement.Shared.Entities;
using CattleFarmManagement.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Dtos.CowDtos
{
    public class ListCowsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TagNumber { get; set; }
        public double Age { get; set; }
        public short Weight { get; set; }
        public ICollection<CowPicture> CowPictures { get; set; }

    }
}
