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
        public IActionResult Add()
        {
            var model = new ProjectAddViewModel();

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
                    return View(model);
                }

                TempData["Success"] = "This project was successfully created.";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                return View(model);
            }
        }
    }
}