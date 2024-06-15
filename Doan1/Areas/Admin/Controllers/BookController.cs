using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Doan1.Models;
using Doan1.Ulitities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Doan1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly DataContext _context;
        public BookController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            
            var mnList=(from m in _context.BookCategorys select new SelectListItem()
            {
                Text=m.Name,Value=m.BookCategoryID.ToString()
            }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "----Xem thêm----",
                Value = string.Empty
            });
            ViewBag.mnList=mnList;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra tính hợp lệ của dữ liệu gửi từ biểu mẫu
                _context.Books.Add(book); // Thêm sách vào cơ sở dữ liệu
                _context.SaveChanges(); // Lưu thay đổi
                return RedirectToAction("Index"); // Chuyển hướng đến trang danh sách mục sách
            }
            return View(book); // Nếu dữ liệu không hợp lệ, hiển thị lại biểu mẫu với thông báo lỗi
        }
        public IActionResult Index()
        {
            
            var items = _context.Books.ToList();
            ViewBag.BookctList=_context.BookCategorys.Where(m=>m.IsActive==true).ToList();
            return View(items);
        }

        public IActionResult Delete(int? id)
        {
            
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Books.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var dele = _context.Books.Find(id);
            if (dele == null)
            {
                return NotFound();
            }
            _context.Books.Remove(dele);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Books.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book mn)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }
    }
}
