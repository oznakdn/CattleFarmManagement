using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Abstract
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public bool IsActive { get; set; } = true;

        public string Description { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime? UpdateDate { get; set; }

    }
}
