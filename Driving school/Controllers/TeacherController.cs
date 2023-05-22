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
        public IActionResult Grading()
        {
            return View("Grading");
        }
        [HttpPost]
        public IActionResult Grading(int id, int grade, string description)
        {
            
            SecurityDAO securityDAO = new SecurityDAO();
            if (string.IsNullOrEmpty(grade.ToString())) { }
            else { securityDAO.UpdateLessonGrade(id, grade); }
            //if (string.IsNullOrEmpty(description)) { }
            //else { securityDAO.UpdateDescription(id, description); }
            securityDAO.UpdateDescription(id, description);
            return RedirectToAction("Grading");
        }

    }
}