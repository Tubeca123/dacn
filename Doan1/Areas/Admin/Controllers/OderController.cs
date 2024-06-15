using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Doan1.Models;
using Doan1.Ulitities;


namespace Doan1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OderController : Controller
    {
        private readonly DataContext _context;

        public OderController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index1()
        {
            ViewBag.Account = _context.Accounts.ToList();
            var items = _context.Oders.Where(o => o.Status == 1).ToList();
            return View(items);
        }
        public IActionResult Index2()
        {
            ViewBag.Account = _context.Accounts.ToList();
            var items = _context.Oders.Where(o => o.Status == 2).ToList();
            return View(items);
        }

        public IActionResult Index3()
        {
            ViewBag.Account = _context.Accounts.ToList();
            var items = _context.Oders.Where(o => o.Status == 3).ToList();
            return View(items);
        }
        public IActionResult Index4()
        {
            ViewBag.Account = _context.Accounts.ToList();
            var items = _context.Oders.Where(o => o.Status == 4).ToList();
            return View(items);
        }

        public IActionResult Index5()
        {
            ViewBag.Account = _context.Accounts.ToList();
            var items = _context.Oders.Where(o => o.Status == 5).ToList();
            return View(items);
        }

        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Oders.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Oder mn)
        {
            if (ModelState.IsValid)
            {
                mn.Status += 1;
                _context.Oders.Update(mn);
                _context.SaveChanges();
                return RedirectToAction("Index1");
            }
            return View(mn);
        }

        public IActionResult Details(int id)
        {
            ViewBag.Book = _context.Books.ToList();

            var items = _context.OderDetais.Where(o => o.OderId == id).ToList();
            return View(items);
        }

    }
}
