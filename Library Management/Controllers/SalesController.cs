using Library_Management.DAL;
using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controllers
{
    public class SalesController : Controller
    {
        private readonly Context _context;

        public SalesController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Lend()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Lend(Sales sales)
        {
            _context.Sales.Add(sales);
            _context.SaveChanges();
            return RedirectToAction("Lend");


        }
    }
}
