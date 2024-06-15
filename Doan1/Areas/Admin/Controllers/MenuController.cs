using Microsoft.AspNetCore.Mvc;
using Doan1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Doan1.Ulitities;

namespace Startup.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly DataContext _context;

        public MenuController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var mnList = _context.Menus.OrderBy(m => m.MenuID).ToList();
            return View(mnList);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) {
                return NotFound();
            }
            var mn = _context.Menus.Find(id);
            if (mn == null)
            {
                return NotFound();
            }

            return View(mn);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleMenu=_context.Menus.Find(id);
            if(deleMenu == null)
            {
                return NotFound();
            }
            _context.Menus.Remove(deleMenu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            var mnList = (from m in _context.Menus
                          select new SelectListItem()
                          {
                              Text = m.MenuName,
                              Value = m.MenuID.ToString(),
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "-------Select------",
                Value = "0"
            });
            ViewBag.mnList = mnList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Menu mn)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra tính hợp lệ của dữ liệu gửi từ biểu mẫu
                _context.Menus.Add(mn); // Thêm menu vào cơ sở dữ liệu
                _context.SaveChanges(); // Lưu thay đổi
                return RedirectToAction("Index"); // Chuyển hướng đến trang danh sách mục menu
            }
            return View(mn); // Nếu dữ liệu không hợp lệ, hiển thị lại biểu mẫu với thông báo lỗi
        }

        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Menus.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            var mnList = (from m in _context.Menus
                          select new SelectListItem()
                          {
                              Text = m.MenuName,
                              Value = m.MenuID.ToString(),
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "---Select----",
                Value = string.Empty
            });
            ViewBag.mnList = mnList;
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Menu mn)
        {
            if (ModelState.IsValid)
            {
                _context.Menus.Update(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }
    }
}
