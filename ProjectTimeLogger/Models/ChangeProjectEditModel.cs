using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTimeLogger.Models
{
    public class ChangeProjectEditModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Project Name")]
        public string Name { get; set; }
        [Required]
        public int Id { get; set; }

    }
}
