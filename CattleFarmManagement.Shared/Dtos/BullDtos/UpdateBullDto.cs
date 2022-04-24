using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Dtos.BullDtos
{
    public class UpdateBullDto
    {

        public int ID { get; set; }
        [Required(ErrorMessage = "Bull's {0} is required!")]
        [MaxLength(30, ErrorMessage = "Bull's {0} must be than less 30 character")]
        [MinLength(2, ErrorMessage = "Bull's {0} must be than more 2 character")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bull's {0} is required!")]
        [StringLength(13, ErrorMessage = "Bull's {0} must be 13 character")]
        public string TagNumber { get; set; }

        [Required(ErrorMessage = "Bull's {0} is required!")]
        public double Age { get; set; }

        [Required(ErrorMessage = "Bull's {0} is required!")]
        public short Weight { get; set; }

        public string Description { get; set; }


 
    }
}
