using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models{
    [Table("Student")]
    public class Studen{
        [Key]
        public int Msv { get; set; }
        public string FullName { get; set; }
        public DateTime NgaySinh { get; set; }
    }
}