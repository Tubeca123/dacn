using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Doan1.Models;
using Doan1.Ulitities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Doan1.Areas.Admin.Models;

namespace Doan1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var accounts = _context.Accounts.Where(m => (m.RoleID == 2)).ToList();
            return View(accounts);
        }

        public IActionResult EditProfile(int id)
        {
            var user = _context.Accounts.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult EditProfile(Account ed)
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
