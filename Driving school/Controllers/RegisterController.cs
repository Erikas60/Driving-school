using Microsoft.AspNetCore.Mvc;
using Driving_school.Models;
using System.Collections.Generic;
using Driving_school.Services;

namespace Driving_school.Controllers
{
    public class RegisterController : Controller
    {
		static List<RegisterModel> registers = new List<RegisterModel>();
        public IActionResult Index()
        {
            return View(registers);
        }
		public IActionResult Create(RegisterModel user)
		{
            //curityService securityService = new SecurityService();
			//curityService.AddStudent(user); 
            return View();
		}
		public IActionResult Details(RegisterModel register)
		{
            SecurityService securityService = new SecurityService();
            securityService.AddStudent(register);
            return View("Details", register);
		}
	}
}
