using Microsoft.AspNetCore.Mvc;

namespace Customer_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
