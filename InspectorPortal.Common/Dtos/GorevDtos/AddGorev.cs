namespace InspectorPortal.Common.Dtos.GorevDtos
{
    public class AddGorev
    {
        public int BirimId { get; set; }
        public List<int> MufettisIds { get; set; }
        public DateTime GorevVerilisTarihi { get; set; }
        public DateTime GorevBaslangicTarihi { get; set; }
        public DateTime GorevBitisTarihi { get; set; }
        public string Konu { get; set; }
    }
}
