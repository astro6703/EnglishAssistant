using Microsoft.AspNetCore.Mvc;

namespace EnglishAssistant.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}