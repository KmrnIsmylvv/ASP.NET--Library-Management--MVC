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

        public IActionResult Index(string bookName)
        {
            var books = from book in _context.Books select book;
            if (!string.IsNullOrEmpty(bookName))
            {
                books = books.Where(b => b.Name.Contains(bookName));
            }

            return View(books.ToList());
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
            Book currentBook = _context.Books.Find(book.Id);

            currentBook.Name = book.Name;
            currentBook.PageNumber = book.PageNumber;
            currentBook.PublishDate = book.PublishDate;
            currentBook.PublishHome = book.PublishHome;
            currentBook.InStock = book.InStock;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}