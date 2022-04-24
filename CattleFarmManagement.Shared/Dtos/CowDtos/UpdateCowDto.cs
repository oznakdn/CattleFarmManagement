using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Shared.Dtos.CowDtos
{
    public class UpdateCowDto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(30, ErrorMessage = "Name is less then 30")]
        [MinLength(2, ErrorMessage = "Name is greater than 2")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Tag Number is required")]
        [MaxLength(13, ErrorMessage = "Tag Number must be 13 character")]
        [MinLength(13, ErrorMessage = "Tag Number must be 13 character")]
        public string TagNumber { get; set; }


        [Required(ErrorMessage = "Age is required")]
        public double Age { get; set; }


        [Required(ErrorMessage = "Weight is required")]
        public short Weight { get; set; }


        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public bool IsActive { get; set; }

      
    }
}
