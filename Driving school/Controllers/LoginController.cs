using Driving_school.Models;
using Driving_school.Services;
using Microsoft.AspNetCore.Mvc;

namespace Driving_school.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(User userModel)
        {
            SecurityService securityService = new SecurityService();
            if(securityService.IsvalidStudent(userModel))
            {
                TempData["IsLoggedIn"] = true;
                TempData.Keep("IsLoggedIn");
                TempData["UserName"] = userModel.Name;
                TempData.Keep("UserName");
                TempData["UserType"] = "Student";
                TempData.Keep("UserType");
                return View("~/Views/Student/index.cshtml", userModel);
            }else if (securityService.IsvalidTeacher(userModel))
            {
                TempData["IsLoggedIn"] = true;
                TempData.Keep("IsLoggedIn");
                TempData["UserName"] = userModel.Name;
                TempData.Keep("UserName");
                TempData["UserType"] = "Teacher";
                TempData.Keep("UserType");
                return View("~/Views/Teacher/index.cshtml", userModel);
            }
            else 
            {
                TempData["IsLoggedIn"] = false;
                return View("LoginFailure", userModel);
            }
            
        }
    }
}
