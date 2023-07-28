using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models{
    [Table("HoaQua")]
    public class HoaQua{
        [Key]
        public string ID { get; set; }
        public string Ten { get; set; }
        public int SoLuong { get; set; }
    }
}