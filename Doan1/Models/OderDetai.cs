
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doan1.Models
{
    [Table("OderDetai")]
    public class OderDetai
    {
        [Key]
        public int OderDetaiId { get; set; }
        public int OderId { get; set; }
        public int BookId { get; set; }
        public decimal price { get; set; }
        public int Quantity { get; set; }

        public decimal IntoMoney { get; set; }
    }
}
