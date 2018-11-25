using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTimeLogger.Models;
using Microsoft.AspNetCore.Http;
using static ProjectTimeLogger.Utility.Exceptions;
using AutoMapper;

namespace ProjectTimeLogger.Data
{
    public class ProjectData : IProjectData
    {
        private IUserData _userData;
        private IMapper _mapper;

        public ProjectData(IUserData userData, IMapper mapper)
        {
            _userData = userData;
            _mapper = mapper;
        }
        
        public void AddProject(ProjectIndexViewModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (model.AddProject == null) throw new ArgumentNullException(nameof(model.AddProject));
            if (model.AddProject.Name == null) throw new ArgumentNullException(nameof(model.AddProject.Name));
            if (model.AddProject.Name == "") throw new ArgumentException($"{nameof(model.AddProject.Name)} must not be empty.");

            using (var db = new postgresContext())
            {
                if (db.Project.Any(x => x.Name == model.AddProject.Name))
                {
                    throw new ProjectAlreadyExistsException();
                }

                db.Project.Add(new Project()
                {
                    Name = model.AddProject.Name,
                    UserId = _userData.GetID()
                });
                                
                db.SaveChanges();
            }
        }

        public List<ChangeProjectEditModel> ShowProjects()
        {
            List<ChangeProjectEditModel> projectList = new List<ChangeProjectEditModel>();

            using (var db = new postgresContext())
            {
                var efList = db.Project.Where(x => x.UserId == _userData.GetID()).OrderBy(x => x.Id);
                
                projectList = efList.Select(x => _mapper.Map<ChangeProjectEditModel>(x)).ToList();

            }
            return projectList;
        }
    }

}

