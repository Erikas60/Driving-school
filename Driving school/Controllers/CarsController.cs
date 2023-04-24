using Microsoft.AspNetCore.Mvc;

namespace Driving_school.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}