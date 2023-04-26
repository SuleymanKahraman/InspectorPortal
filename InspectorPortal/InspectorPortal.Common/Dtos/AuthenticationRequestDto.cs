namespace InspectorPortal.Common.Dtos
{

    //Data Transfer Object olarak tanımlanan sınıfımızda esasen veri tabanından alınan spesifik verilen kullanıcıya gönderilmesi işlemleri için açılır. Y
    public class AuthenticationRequestDto
    {
        public string Email { get; set; }
        public string Sifre { get; set; }
    }
}