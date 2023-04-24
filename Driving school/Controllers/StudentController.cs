using Driving_school.Models;
using Driving_school.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Driving_school.Controllers
{
	public class StudentController : Controller
	{

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}
		public IActionResult Details()
		{
			return View();
		}
        public IActionResult History(User user)
        {
			
            return View("History");
        }
        public IActionResult Schedule(User user)
        {
            
            return View("Schedule");
        }
        public IActionResult Mistakes()
        {
            return View("Mistakes");
        }
        public IActionResult ToList()
        {
            return View("Index");
        }

    }
}