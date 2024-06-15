using Doan1.Models;
using Microsoft.AspNetCore.Mvc;
namespace Doan1.Components
{
	[ViewComponent(Name = "MenuView")]

	public class MenuViewComponent : ViewComponent
	{
		private DataContext _context;
		public MenuViewComponent(DataContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var listofMenu = (from m in _context.Menus
							  where (m.IsActive == true)
							  select m).ToList();

			return await Task.FromResult((IViewComponentResult)View("Default", listofMenu));
		}


	}
}
