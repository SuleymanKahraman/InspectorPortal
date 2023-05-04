using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InspectorPortal.Data.Entities
{
    [Table("Kullanicilar")]
    public class Kullanici
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Isim { get; set; }
        [Required]
        public string Soyisim { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Parola { get; set; }
    }
}
