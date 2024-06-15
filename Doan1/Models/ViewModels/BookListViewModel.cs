namespace Doan1.Models.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; } = Enumerable.Empty<Book>();
        public PagingInfo PagingInfo { get; set; }=new PagingInfo();
    }
}
