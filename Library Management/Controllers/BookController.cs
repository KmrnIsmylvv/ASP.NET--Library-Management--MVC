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

        public IActionResult Delete(int id)
        {
            Book book = _context.Books.FirstOrDefault(c => c.Id == id);
            _context.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Book book = _context.Books.FirstOrDefault(b => b.Id == id);

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

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            Category category = _context.Categories.FirstOrDefault(c => c.Id == book.CategoryId);
            Author author = _context.Authors.FirstOrDefault(a => a.Id == book.AuthorId);

            Book currentBook = _context.Books.Find(book.Id);

            currentBook.Name = book.Name;
            currentBook.PageNumber = book.PageNumber;
            currentBook.PublishDate = book.PublishDate;
            currentBook.PublishHome = book.PublishHome;
            currentBook.InStock = book.InStock;
            currentBook.CategoryId = category.Id;
            currentBook.AuthorId = author.Id;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}