using Microsoft.AspNetCore.Mvc;

namespace STVMatrimonyAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
