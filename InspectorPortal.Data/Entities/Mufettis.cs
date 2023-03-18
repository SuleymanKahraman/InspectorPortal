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
    [Table("Mufettisler")]
    public class Mufettis
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Isim { get; set; }

        [Required]
        [MaxLength(64)]
        public string Soyisim { get; set; }

        [Required]
        [MaxLength(128)]
        public string Email { get; set; }

        [Required]
        [MaxLength(128)]
        public string Sifre { get; set; }

        [Required]
        [MaxLength(50)]
        public string TcNo { get; set; }
        [Required]
        public DateTime DogumTarihi { get; set; }
        [MaxLength(50)] 
        public string DogumYeri { get; set; }
        [MaxLength(50)]
        public string BabaAdi { get; set; }
        [MaxLength(50)]
        public string MedeniHal { get; set; }
        [MaxLength(50)]
        public string MezunOkul { get; set; }

        public DateTime IseBaslama { get; set; }
        [MaxLength(50)]
        public string KurumSicilNo { get; set; }
        [MaxLength(50)]
        public string MufettisNo { get; set; }
        [MaxLength(50)]
        public string Unvan { get; set; }
        [MaxLength(50)]
        public string CalismaDurumu { get; set; }
        [MaxLength(50)]
        public string Telefon { get; set; }
        [MaxLength(500)]
        public string Adres { get; set; }


        
    }
}
