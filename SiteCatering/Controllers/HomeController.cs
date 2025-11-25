using Microsoft.AspNetCore.Mvc;

namespace SiteCatering.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
