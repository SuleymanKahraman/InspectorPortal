using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace InspectorPortal.Data.Entities
{
    [Table("UniteBirimler")]
    public class UniteBirim 
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Birim { get; set; }

        [Required]
        [MaxLength(100)]
        public string BirimSorumlusu { get; set; }

        [Required]  
        public int BirimID { get; set; }

        [ForeignKey(nameof(BirimID))]
        public virtual UniteBirim UstBirim { get; set; }

    }
}
