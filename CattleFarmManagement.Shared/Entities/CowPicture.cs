﻿using CattleFarmManagement.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Entities
{
    public class CowPicture:BaseEntity,IEntity
    {
        public string PictureName { get; set; }

        public int CowId { get; set; }
        public Cow Cow { get; set; }

    }
}
