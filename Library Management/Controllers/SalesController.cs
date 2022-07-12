using Library_Management.DAL;
using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
            List<Sales> sales = _context.Sales
                .Include(s => s.Book)
                .Include(s => s.Member)
                .ToList();
            return View(sales);
        }

        [HttpGet]
        public IActionResult Lend()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Lend(Sales sales)
        {
            Book book = _context.Books.FirstOrDefault(b => b.Id == sales.BookId);
            book.InStock = false;

            _context.Sales.Add(sales);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult TakeBack(int id)
        {
            Sales sales = _context.Sales
                .Include(s => s.Book)
                .Include(s => s.Member)
                .FirstOrDefault(s => s.Id == id);

            return View(sales);
        }

        [HttpPost]
        public IActionResult TakeBack(Sales sales)
        {
            Book book = _context.Books.FirstOrDefault(b => b.Id == sales.BookId);
            book.InStock = true;

            Sales currentSales = _context.Sales.Find(sales.Id);
            currentSales.GivenTime = sales.GivenTime;
            currentSales.IsCompleted = true;

            

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
