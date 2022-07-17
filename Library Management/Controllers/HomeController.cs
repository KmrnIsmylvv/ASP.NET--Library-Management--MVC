﻿using Library_Management.DAL;
using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management.Controllers
{
    public class HomeController : Controller 
    {
        private readonly Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            List<Book> books = _context.Books.ToList();

            return View(books);
        }
    }
}
