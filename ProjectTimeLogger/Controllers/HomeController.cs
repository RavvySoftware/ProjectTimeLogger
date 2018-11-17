using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectTimeLogger.Models;

namespace ProjectTimeLogger.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new postgresContext())
            {

            }

            return View();
        }
    }
}
