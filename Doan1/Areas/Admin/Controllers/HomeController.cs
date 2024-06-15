using Microsoft.AspNetCore.Mvc;
using Doan1.Ulitities;
namespace Doan1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (!Functions.IsLoginAdmin())
            {
                return RedirectToAction("Index", "Login");

            }
            return View();
        }

        public IActionResult Logout()
        {
            Functions._AccountID = 0;
            Functions._FullName = string.Empty;
            Functions._Email = string.Empty;
            Functions._Message = string.Empty;
            Functions._MessageEmail= string.Empty;
            return RedirectToAction("Index", "Login");
        }
    }
}
