namespace InspectorPortal.Common.Dtos.UniteBirimDtos
{
    public class ListAllGorev
    {
        public int GorevId { get; set; }
        public string BaslangicTarihi { get; set; }
        public string BitisTarihi { get; set; }
        public string Konu { get; set; }
        public List<string> GorevliMufettisler { get; set; }
        public string BirimAdi { get; set; }
        public int BirimId { get; set; }
    }
}
