using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectorPortal.Common.Dtos.AuthenticationDtos
{
    public class AuthenticationResultDto
    {
        public int KullaniciID { get; set; }
        public int? MufettisID { get; set; }
        public string Photo { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string Unvan { get; set; }
        public string Token { get; set; }
    }
}
