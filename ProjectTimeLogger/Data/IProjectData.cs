using ProjectTimeLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTimeLogger.Data
{
    public interface IProjectData
    {
        void AddProject(ProjectIndexViewModel model);
        List<ChangeProjectEditModel> ShowProjects();
    }
}
