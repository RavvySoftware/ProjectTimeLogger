using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTimeLogger.Models;
using Microsoft.AspNetCore.Http;
using static ProjectTimeLogger.Utility.Exceptions;

namespace ProjectTimeLogger.Data
{
    public class ProjectData : IProjectData
    {
        private IUserData _userData;

        public ProjectData(IUserData userData)
        {
            _userData = userData;
        }

        public void AddProject(ProjectAddViewModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (model.ProjectName == null) throw new ArgumentNullException(nameof(model.ProjectName));
            if (model.ProjectName == "") throw new ArgumentException($"{nameof(model.ProjectName)} must not be empty.");

            using (var db = new postgresContext())
            {
                if (db.Project.Any(x => x.Name == model.ProjectName))
                {
                    throw new ProjectAlreadyExistsException();
                }

                db.Project.Add(new Project()
                {
                    Name = model.ProjectName,
                    UserId = _userData.GetID()
                });
                
                db.SaveChanges();
            }
        }
    }
}
