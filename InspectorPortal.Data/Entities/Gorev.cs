using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectorPortal.Data.Entities
{
    [Table("Gorevler")]
    public class Gorev
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Konusu { get; set; }
        [Required]
        public int UnitID { get; set; }

        [ForeignKey(nameof(UnitID))]
        public virtual UniteBirim UniteBirim { get; set; }

        [Required]
        public DateTime VerilisTarihi { get; set; }
        [Required]
        public DateTime BaslamaTarihi { get; set; }
        [Required]
        public DateTime BitisTarihi { get; set; }
        
        public bool Durum { get; set; }

       


    }
}
