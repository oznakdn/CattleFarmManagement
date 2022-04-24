using CattleFarmManagement.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Entities
{
    public class Borning:BaseEntity,IEntity
    {

        public DateTime BirthDate { get; set; }
        public short BornWeight { get; set; }
        public int? FatherId { get; set; }
        public int? MotherId { get; set; }

    }
}
