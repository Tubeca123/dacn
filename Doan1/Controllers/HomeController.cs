using Doan1.Areas.Admin.Models;
using Doan1.Models;
using Doan1.Ulitities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace Doan1.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly DataContext _context;
		public HomeController(ILogger<HomeController> logger,DataContext context)
		{
			_logger = logger;
			_context = context; 
		}

		public IActionResult Index()
		{
			return View();
		}


		public IActionResult Privacy()
		{
			return View();
		}
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Account user)
        {
            if (user == null)
            {
                return NotFound();
            }
            var check = _context.Accounts.Where(m => m.Email == user.Email).FirstOrDefault();
            if (check != null)
            {
                Functions._MessageEmail = "Duplication Email";
                return RedirectToAction("Register", "Home");
            }
            Functions._MessageEmail = string.Empty;
            user.Password = Functions.MD5PassWord(user.Password);
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Account user)
        {
            if (user == null)
            {
                return NotFound();
            }
            string pw = Functions.MD5PassWord(user.Password);
            var check = _context.Accounts.Where(m => (m.Email == user.Email) && (m.Password == pw)&&(m.RoleID==2)).FirstOrDefault();
            if (check == null)
            {
                Functions._Message = "Tên hoặc mật khẩu không hợp ";
                return RedirectToAction("Login", "Home");
            }
            Functions._AccountID = check.AccountId;
            Functions._FullName = check.FullName;
            Functions._UserName = check.UserName;
            Functions._Phone = check.Phone;
            Functions._Avatar = check.Avatar;
            Functions._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Logouts()
        {
            Functions._AccountID = 0;
            Functions._FullName = string.Empty;
            Functions._Email = string.Empty;
            Functions._Message = string.Empty;
            Functions._MessageEmail = string.Empty;
            return RedirectToAction("Login", "Home");
        }

        public IActionResult Profile()
        {
            var item = _context.Accounts.FirstOrDefault(a => a.AccountId == Functions._AccountID);
            return View(item);
        }

        public IActionResult EditProfile(int id)
        {
            var user = _context.Accounts.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult EditProfile(Account ed)
        {
            if (ModelState.IsValid)
            {
                _context.Accounts.Update(ed);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ed);
        }
    }
}