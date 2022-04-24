using CattleFarmManagement.Shared.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Dtos.CalvingDtos
{
    public class CreateCalvingDto
    {
        public DateTime DryingDate { get; set; }
        public DateTime BirthDate { get; set; }
        public double DryingPeriod { get; set; }
        public GenderType Gender { get; set; }
        public bool IsAlive { get; set; }
        public short Weight { get; set; }
        public BorningType BorningType { get; set; }

        public IFormFile[] pictureFiles { get; set; }

        public string Description { get; set; }

        public int CowId { get; set; }
        public int BullId { get; set; }
    }
}
