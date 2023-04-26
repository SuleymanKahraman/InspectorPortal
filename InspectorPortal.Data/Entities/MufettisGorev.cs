using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectorPortal.Data.Entities
{
    [Table("MufettisGorevleri")]

    public class MufettisGorev
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int MufettisID { get; set; }

        [ForeignKey(nameof(MufettisID))]
        public virtual Mufettis Mufettis { get; set; }

        [Required]
        public int GorevID { get; set; }

        [ForeignKey(nameof(GorevID))]
        public virtual Gorev Gorev { get; set; }

    }
}
