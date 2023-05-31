using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectorPortal.Common.Dtos.GorevDtos
{
    public class UpdateGorev
    {
        public int BirimId { get; set; }
        public List<int> MufettisIds { get; set; }
        public DateTime GorevVerilisTarihi { get; set; }
        public DateTime GorevBaslangicTarihi { get; set; }
        public DateTime GorevBitisTarihi { get; set; }
        public string Konu { get; set; }
        public bool Durum { get; set; }   
    }
}
