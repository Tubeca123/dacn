using Doan1.Infrastructure;
using Doan1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Doan1.Components
{
	public class CartWidget:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			// Lấy giỏ hàng từ Session

			// Truyền giỏ hàng vào view để hiển thị
			return View(HttpContext.Session.GetJson<Cart>("cart"));
		}


	}
}
