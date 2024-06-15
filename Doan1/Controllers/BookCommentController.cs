using Microsoft.AspNetCore.Mvc;
using Doan1.Models.ViewModels;
using Doan1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Doan1.Ulitities;

namespace Doan1.Controllers
{
    public class BookCommentController : Controller
    {
        private readonly DataContext _context;
        public BookCommentController(DataContext context)
        {
            _context = context;
        }
        [HttpPost]
        public bool Add(string message, int id)
        {
            try
            {
                if (string.IsNullOrEmpty(message))
                {
                    Functions._Message = "Nội dung phản hồi không được để trống !";
                    return false;
                }
                BookComment comment = new BookComment();
                comment.AccountID = Functions._AccountID;
                comment.CreateDate = DateTime.Now;
                comment.Details = message;
                comment.BookID = id;
                comment.ModifiedDate = DateTime.Now;
                comment.IsActive = true;
                _context.BookComments.Add(comment);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
