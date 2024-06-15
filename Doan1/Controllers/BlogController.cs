using Microsoft.AspNetCore.Mvc;
using Doan1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Doan1.Controllers
{
    public class BlogController : Controller
    {
        private readonly DataContext _context;
        public BlogController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var items = _context.Blogs.Where(m => m.IsActive == true).ToList();
            return View(items);
        }

        public IActionResult Details(int? id)
        {

            var items = _context.Blogs.Where(m => m.IsActive == true).ToList();
            return View(items);
        }
    }
}
