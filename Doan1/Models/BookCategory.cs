using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace Doan1.Models
{
	[Table("BookCategory")]
	public class BookCategory
	{
		[Key]
		public int BookCategoryID { get; set; }

		public string? Name { get; set; }

		public string? Alias { get; set; }

		public string? Description { get; set; }

		public int Position { get; set; }

		public DateTime? CreatedDate { get; set; }

		public string? CreatedBy { get; set; }

		public DateTime? ModifiedDate { get; set; }

		public string? ModifiedBy { get; set; }

		public bool? IsActive { get; set; }
		public string? Image {  get; set; }
	}
}
