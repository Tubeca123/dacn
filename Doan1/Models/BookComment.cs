using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace Doan1.Models
{
    [Table("BookComment")]
    public class BookComment
    {
        [Key]
        public int BookCommentId { get; set; }
        public int AccountID { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Details { get; set; }
        public int BookID { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

    }
}
