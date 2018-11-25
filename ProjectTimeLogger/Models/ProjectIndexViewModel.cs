using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTimeLogger.Models
{
    public class ProjectIndexViewModel
    {
        public ProjectIndexViewModel()
        {
            AddProject = new ProjectEditModel();
            ShowProjects = new List<ChangeProjectEditModel>();
        }

        public ProjectEditModel AddProject { get; set; }
        public List<ChangeProjectEditModel> ShowProjects { get; set; }
    }
}
