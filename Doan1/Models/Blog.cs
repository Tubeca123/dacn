using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace Doan1.Models
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        public int PostID { get; set; }
        public string? Title { get; set; }
        public string? Abstract { get; set; }
        public string? Image { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
