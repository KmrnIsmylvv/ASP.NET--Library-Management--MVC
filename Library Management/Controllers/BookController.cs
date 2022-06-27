using Library_Management.DAL;
using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management.Controllers
{
    public class BookController : Controller
    {
        private readonly Context _context;

        public BookController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Book> books = _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .ToList();

            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> categories = (from i in _context.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.Name,
                                                   Value = i.Id.ToString()
                                               }).ToList();

            List<SelectListItem> authors = (from i in _context.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.FirstName + " " + i.LastName,
                                                Value = i.Id.ToString()
                                            }).ToList();
            ViewBag.Author = authors;
            ViewBag.Category = categories;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {

            Category category = _context.Categories.FirstOrDefault(c => c.Id == book.CategoryId);
            Author author = _context.Authors.FirstOrDefault(a => a.Id == book.AuthorId);

            book.Category = category;
            book.Author = author;

            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
