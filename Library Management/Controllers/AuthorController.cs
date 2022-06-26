using Library_Management.DAL;
using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management.Controllers
{
    public class AuthorController : Controller
    {
        private readonly Context _context;

        public AuthorController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Author> authors = _context.Authors.ToList();
            return View(authors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Error");
            }

            _context.Authors.Add(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Author author = _context.Authors.Find(id);
            _context.Authors.Remove(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Author author = _context.Authors.FirstOrDefault(a => a.Id == id);
            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            Author currentAuthor = _context.Authors.FirstOrDefault(a => a.Id == author.Id);

            currentAuthor.FirstName = author.FirstName;
            currentAuthor.LastName = author.LastName;
            currentAuthor.About = author.About;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
