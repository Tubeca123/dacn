using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Doan1.Infrastructure;
using Doan1.Models;
using Doan1.Areas.Admin.Models;
using Doan1.Ulitities;

namespace Doan1.Controllers
{
    public class OderController : Controller
    {
        private readonly DataContext _context;
        public OderController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Order()
        {
            if (ModelState.IsValid)
            {
                Account? profile = _context.Accounts.FirstOrDefault(c => c.AccountId == Functions._AccountID);
                Cart? Cart = HttpContext.Session.GetJson<Cart>("cart");
                if (Cart != null)
                {
                    Oder Oder = new Oder();
                    Random rd = new Random();
                    Oder.Code = "DH" + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9);
                    Oder.AccounId = profile.AccountId;
                    Oder.Status = 1;
                    Oder.Total  = Cart.ComputeTotalValue();
                    Oder.CreateDate = DateTime.Now;
                    _context.Oders.Add(Oder);
                    _context.SaveChanges();
                    var OderId = _context.Oders.FirstOrDefault(m => (m.Code == Oder.Code) && (m.CreateDate == Oder.CreateDate));
                    foreach (var item in Cart.Lines)
                    {
                        OderDetai orderDetail = new OderDetai
                        {
                            OderId = Oder.OderId,
                            BookId = item.Product.BookID,
                            price = item.Product.Price - item.Product.PriceSale,
                            Quantity = item.Quantity,
                            IntoMoney = (item.Product.Price - item.Product.PriceSale) * item.Quantity
                        };

                        _context.OderDetais.Add(orderDetail);
                    }
                    _context.SaveChanges();
                    Cart.Clear();
                    HttpContext.Session.SetJson("cart", Cart);
                }
            }
            return RedirectToAction("ListOder");
        }

        public IActionResult ListOder()
        {
           
            var Account = _context.Accounts.FirstOrDefault(c => (c.AccountId == Functions._AccountID));
/*            ViewBag.Status = _context.tbOrderStatuses.ToList();
*/          var items = _context.Oders.Where(o => (o.AccounId == Account.AccountId)).OrderByDescending(o => o.CreateDate).ToList();
            return View(items);
        }

        [HttpPost]
        public ActionResult Cancel(int id)
        {
            var item  = _context.Oders.Find(id);
            if (item  == null)
            {
                return NotFound();
            }
            item.Status = 5;
            _context.SaveChanges();
            return RedirectToAction("ListOder");
        }

        [HttpPost]
        public ActionResult Ok(int id)
        {
            var item = _context.Oders.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.Status = 4;
            _context.SaveChanges();
            return RedirectToAction("ListOder");
        }
        public IActionResult Detail(int id)
        {
            ViewBag.Book = _context.Books.ToList();

            var items = _context.OderDetais.Where(o => o.OderId == id).ToList();
            return View(items);
        }
    }
}
