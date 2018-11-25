using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTimeLogger.Data;
using ProjectTimeLogger.Models;
using static ProjectTimeLogger.Utility.Exceptions;

namespace ProjectTimeLogger.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectData _projectData;

        public ProjectController(IProjectData projectData)
        {
            _projectData = projectData;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new ProjectIndexViewModel();
            model.AddProject.Name = TempData["ProjectName"]?.ToString();
            model.ShowProjects = _projectData.ShowProjects();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ProjectIndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _projectData.AddProject(model);
                }
                catch (ProjectAlreadyExistsException)
                {
                    TempData["Error"] = "This project already exists.";
                    TempData["ProjectName"] = model.AddProject.Name;
                    
                    return RedirectToAction(nameof(Index));
                }

                TempData["Success"] = "This project was successfully created.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }
    }
}