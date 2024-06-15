using Doan1.Models;
using Microsoft.AspNetCore.Mvc;
namespace Doan1.Components
{
	[ViewComponent(Name = "Story")]
	public class Story:ViewComponent
	{
		private readonly DataContext _context;
		public Story(DataContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var list = (from p in _context.Books
						where (p.IsActive == true)
						orderby p.BookID descending
						select p).ToList();
			return await Task.FromResult((IViewComponentResult)View("Default", list));
		}
	}
}
