using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Dtos.MilkRecordDtos
{
    public class UpdateMilkRecordDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Record Number is required")]
        public short RecordNumber { get; set; }

        [Required(ErrorMessage = "Record Date is required")]
        public DateTime RecordDate { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public short Quantity { get; set; }
        
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public int CowId { get; set; }
    }
}
