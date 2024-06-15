using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Doan1.Models;
using System.Runtime.InteropServices;
using Doan1.Ulitities;
namespace Doan1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly DataContext _context;
        public BlogController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var items = _context.Blogs.ToList();
            return View(items);
        }


        public IActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Blogs.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Blog mn)
        {
            if (ModelState.IsValid)
            {
                _context.Blogs.Update(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }

        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Blogs.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var dele = _context.Blogs.Find(id);
            if (dele == null)
            {
                return NotFound();
            }
            _context.Blogs.Remove(dele);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Blog bc)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra tính hợp lệ của dữ liệu gửi từ biểu mẫu
                _context.Blogs.Add(bc); // Thêm menu vào cơ sở dữ liệu
                _context.SaveChanges(); // Lưu thay đổi
                return RedirectToAction("Index"); // Chuyển hướng đến trang danh sách mục menu
            }
            return View(bc); // Nếu dữ liệu không hợp lệ, hiển thị lại biểu mẫu với thông báo lỗi
        }
    }
}
