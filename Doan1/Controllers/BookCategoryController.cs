using Microsoft.AspNetCore.Mvc;
using Doan1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Doan1.Controllers
{
    public class BookCategoryController : Controller
    {
        private readonly DataContext _context;
        public BookCategoryController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var items = _context.BookCategorys.Where(m => m.IsActive == true).ToList();
            return View(items);
        }
    }
}
