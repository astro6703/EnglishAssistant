using EnglishAssistant.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace EnglishAssistant.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new HomeViewModel { Title = "Home page" });
        }
    }
}