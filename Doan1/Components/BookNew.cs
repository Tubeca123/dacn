using Doan1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Doan1.Components
{
    [ViewComponent(Name = "BookNew")]
    public class BookNew:ViewComponent
    {
        private readonly DataContext _context;
        public BookNew(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = (from p in _context.Books
                        where (p.IsActive == true && p.IsNew==true)
                        orderby p.BookID descending
                        select p).Take(8).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", list));
        }
    }
}
