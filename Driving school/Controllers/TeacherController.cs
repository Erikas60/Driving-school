using Driving_school.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Driving_school.Services;

namespace Driving_school.Controllers
{
    public class TeacherController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddLesson(Lesson lesson)
        {
            SecurityService securityService = new SecurityService();
            securityService.AddLesson(lesson);
            return View("AddLesson");
        }
        public IActionResult AddMistake(Mistake mistake)
        {
            SecurityService securityService = new SecurityService();
            securityService.AddMistake(mistake);
            return View("AddMistake");
        }

    }
}