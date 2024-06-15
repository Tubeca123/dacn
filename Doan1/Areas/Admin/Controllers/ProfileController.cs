using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Doan1.Models;
using Doan1.Ulitities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Doan1.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Doan1.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ProfileController : Controller
    {
        private readonly DataContext _context;
        public ProfileController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var item = _context.Accounts.FirstOrDefault(a=> a.AccountId==Functions._AccountIDA);
            return View(item);
        }
        public IActionResult Edit(int id)
        {
            var user = _context.Accounts.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(Account ed)
        {
            if (ModelState.IsValid)
            {
                _context.Accounts.Update(ed);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ed);
        }
    }
}
