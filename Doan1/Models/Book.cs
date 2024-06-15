using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace Doan1.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string? BookName { get; set; }
        public string? Alias { get; set; }
        public int BookCategoryID { get; set; }
        public string? Description { get; set; }
        public string? Abstract { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public decimal PriceSale { get; set; }
        public bool? IsNew { get; set; }
        public bool? IsSale { get; set; }
        public bool? IsBestSeller { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
