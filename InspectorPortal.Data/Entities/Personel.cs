using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectorPortal.Data.Entities
{
    [Table("Personeller")]
    public class Personel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string İsim { get; set; }
        [Required]
        [MaxLength(100)]
        public string Soyisim { get; set; }
        [Required]
        [MaxLength(100)]
        public string SicilNo { get; set; }
    }
}
