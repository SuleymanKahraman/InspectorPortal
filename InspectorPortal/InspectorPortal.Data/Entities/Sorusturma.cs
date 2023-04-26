using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectorPortal.Data.Entities
{
    [Table("Sorusturmalar")]
    public class Sorusturma
    {
        [Key]
        [Required]  
        public int Id { get; set; }

        [Required]
        public int GorevID { get; set; }

        [ForeignKey(nameof(GorevID))]
        public virtual Gorev Gorev { get; set; }

        [Required]
        public int PersonelID { get; set; }
        [ForeignKey(nameof(PersonelID))]
        public virtual Personel SorumluPersonel { get; set; }
    }
}
