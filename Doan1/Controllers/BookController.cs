using Microsoft.AspNetCore.Mvc;
using Doan1.Models.ViewModels;
using Doan1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Doan1.Controllers
{
    public class BookController : Controller
    {
        private readonly DataContext _context;
        public int PageSize = 9;
        public BookController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index(int bookPage=1)
        {
            var mnList = (from m in _context.BookCategorys
                          select new SelectListItem()
                          {
                              Text = m.Name,
                              Value = m.BookCategoryID.ToString()
                          }).ToList();

            mnList.Insert(0, new SelectListItem()
            {
                Text = string.Empty,
                Value = string.Empty
            });

            ViewBag.mnList = mnList;
            return View(
                new BookListViewModel
                {
                    Books=_context.Books
                    .Skip((bookPage-1)*PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo()
                    {
                        ItemsPerPage= PageSize,
                        CurrentPage=bookPage,
                        TotalItems=_context.Books.Count()
                    }

                }


                );
        }
        [HttpPost]
        public IActionResult Search(string keywords,int bookPage = 1)
        {
            var mnList = (from m in _context.BookCategorys
                          select new SelectListItem()
                          {
                              Text = m.Name,
                              Value = m.BookCategoryID.ToString()
                          }).ToList();

            mnList.Insert(0, new SelectListItem()
            {
                Text = string.Empty,
                Value = string.Empty
            });

            ViewBag.mnList = mnList;
            return View("Index",
                new BookListViewModel
                {
                    Books = _context.Books.Where(m => (m.IsActive == true) && (m.BookName.Contains(keywords)))
                    .Skip((bookPage - 1) * PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo()
                    {
                        ItemsPerPage = PageSize,
                        CurrentPage = bookPage,
                        TotalItems = _context.Books.Count()
                    }

                }


                );
        }

        public IActionResult List(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mnList = (from m in _context.BookCategorys
                          select new SelectListItem()
                          {
                              Text = m.Name,
                              Value = m.BookCategoryID.ToString()
                          }).ToList();

            mnList.Insert(0, new SelectListItem()
            {
                Text = string.Empty,
                Value = string.Empty
            });

            ViewBag.mnList = mnList;

            var list = _context.Books
                .Where(m => m.BookCategoryID == id && m.IsActive == true)
                .ToList();

            if (list == null)
            {
                return NotFound();
            }

            return View(list);
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = _context.Books
                .FirstOrDefault(m => (m.BookID == id) && (m.IsActive == true));
            if (item == null)
            {
                return NotFound();
            }
            ViewBag.BookctList = _context.BookCategorys.Where(m => m.IsActive == true).ToList();
            ViewBag.Comment=_context.BookComments.Where(m=>m.BookID==id).ToList();
            ViewBag.Accou = _context.Accounts.ToList();
            return View(item);
        }
    }
}
