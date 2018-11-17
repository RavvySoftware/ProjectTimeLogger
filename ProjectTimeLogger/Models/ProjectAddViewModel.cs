using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTimeLogger.Models
{
    public class ProjectAddViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
    }
}
