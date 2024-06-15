using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Doan1.Areas.Admin.Models;
using Doan1.Models;
using Doan1.Ulitities;
namespace Doan1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly DataContext _context;
        public LoginController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Account user)
        {
            if(user == null)
            {
                return NotFound();
            }
            string pw=Functions.MD5PassWord(user.Password);
            var check =_context.Accounts.Where(m=>(m.Email==user.Email)&&(m.Password == pw)&&(m.RoleID==1)).FirstOrDefault();
            if(check == null)
            {
                Functions._Message = "Tên hoặc mật khẩu không hợp ";
                return RedirectToAction("Index", "Login");
            }
            Functions._AccountIDA = check.AccountId;
            Functions._FullNameA = check.FullName;
            Functions._UserNameA = check.UserName;
            Functions._PhoneA = check.Phone;
            Functions._AvatarA = check.Avatar;
            Functions._EmailA= string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;
            return RedirectToAction("Index","Home");
        }
    }
}
