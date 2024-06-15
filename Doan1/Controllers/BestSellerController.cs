using Doan1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Doan1.Controllers
{
    public class BestSellerController : Controller
    {
        private readonly DataContext _context;
        public BestSellerController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var items = _context.Books.Where(m => (m.IsActive == true)&&(m.IsBestSeller==true)).ToList();
            var mnList = (from m in _context.BookCategorys
                          select new SelectListItem()
                          {
                              Text = m.Name,
                              Value = m.BookCategoryID.ToString()
                          }).ToList();

            mnList.Insert(0, new SelectListItem()
            {
                Text = string.Empty,
                Value = string.Empty
            });

            ViewBag.mnList = mnList;
            return View(items);
        }
    }
}
