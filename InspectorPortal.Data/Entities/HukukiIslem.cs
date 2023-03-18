using InspectorPortal.Common.Enums;
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
    [Table("HukukiIslemler")]
    public class HukukiIslem
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int GorevID { get; set; }

        [ForeignKey(nameof(GorevID))]
        public virtual Gorev Gorev { get; set; }
        public string MufettisOneri { get; set; }
        public string BaskanlikOneri { get; set; }
        public Oneri Onaylanan { get; set; }
    }
}
