using Library_Management.DAL;
using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using System.Collections.Generic;
using System.Linq;

namespace Library_Management.Controllers
{
    public class MemberController : Controller
    {
        private readonly Context _context;

        public MemberController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var members = _context.Members.ToList();
            return View(members);
        }

        public IActionResult Delete(int id)
        {
            Member member = _context.Members.FirstOrDefault(m => m.Id == id);
            _context.Members.Remove(member);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Member member = _context.Members.FirstOrDefault(m => m.Id == id);
            return View(member);
        }

        [HttpPost]
        public IActionResult Edit(Member member)
        {
            Member currentMember = _context.Members.Find(member.Id);

            currentMember.FirstName = member.FirstName;
            currentMember.LastName = member.LastName;
            currentMember.PhoneNumber = member.PhoneNumber;
            currentMember.Email = member.Email;
            currentMember.University = member.University;
            currentMember.Username = member.Username;
            
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
