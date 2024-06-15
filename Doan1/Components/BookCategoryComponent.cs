using Doan1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Doan1.Components
{
    [ViewComponent(Name ="BookCategory")]
    public class BookCategoryComponent : ViewComponent
    {
        private readonly DataContext _context;
        public BookCategoryComponent(DataContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var list = _context.BookCategorys
                            .Where(p => (p.IsActive == true)&&( p.Position<=5))
                            .OrderByDescending(p => p.BookCategoryID)
                            .Take(2)
                            .ToList();

            return View("Default", list);
        }
    }
}
