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
        public ActionResult Index()
        {
            return View();
        }
    }
}
