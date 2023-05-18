using InspectorPortal.Common.Dtos.MufettisDtos;

namespace InspectorPortal.Common.Dtos.GorevDtos
{
    public class ListOfGorevById
    {
        public DateTime VerilisTarihi { get; set; }
        public DateTime BaslamaTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string Konu { get; set; }
        public List<string> GorevliMufettisler { get; set; }
        public string BirimAdi { get; set; }
        public int BirimId { get; set; }
        public bool Durum { get; set; }

    }
}
