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
            var model = new ProjectAddViewModel();
            model.ProjectName = TempData["ProjectName"]?.ToString();

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ProjectAddViewModel model)
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
                    TempData["ProjectName"] = model.ProjectName;
                    
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