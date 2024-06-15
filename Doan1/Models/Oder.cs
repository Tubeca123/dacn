using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doan1.Models
{
    [Table("Oder")]
    public class Oder
    {
        [Key]
        public int OderId { get; set; }

        public int AccounId { get; set; }
        public decimal Total { get; set; }
        public DateTime CreateDate { get; set; }

        public int Status { get; set; }

        public string Code { get; set; }
    }
}