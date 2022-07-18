using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
