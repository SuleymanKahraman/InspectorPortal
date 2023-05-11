using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectorPortal.Common.Dtos.MufettisDtos
{
    public class ListAllMufettis
    {
        public int MufettisId { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string KurumSicilNo { get; set; }
        public string Unvan { get; set; }

    }
}
