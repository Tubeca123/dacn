using Microsoft.AspNetCore.Mvc;
using Doan1.Models;
using Doan1.Areas.Admin.Models;
using Doan1.Infrastructure;
using Doan1.Ulitities;
namespace Doan1.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _context;
        public CartController(DataContext context)
        {
            _context = context;
        }
        public Cart? Cart { get; set; }
        
        public IActionResult Index()
        {
            return View("Cart",HttpContext.Session.GetJson<Cart>("cart"));
        }
        public IActionResult Details()
        {
            Account? account=_context.Accounts.FirstOrDefault(p=>p.AccountId==Functions._AccountID);
            ViewBag.Profile = account;

            return View("Details", HttpContext.Session.GetJson<Cart>("cart"));
        }
        public IActionResult AddToCart(int id,int quantity)
        {
            Book? product = _context.Books.FirstOrDefault(p => p.BookID == id);
            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, quantity);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return Json(new { success = true, cartItemCount = Cart?.Lines.Count, TotalPrice = Cart?.ComputeTotalValue() });
        }
        public IActionResult Remove(int id)
        {
            Book? product = _context.Books.FirstOrDefault(p => p.BookID == id);
            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart");
                Cart.RemoveLine(product);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return View("Cart", Cart);
        }
        /*[HttpPost]
        *//*public IActionResult Update(int id, int quantity)
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart");
            if (Cart != null)
            {
                Cart.Update(id, quantity);
                HttpContext.Session.SetJson("cart", Cart);
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }*/
    }
}
