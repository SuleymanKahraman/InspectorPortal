namespace InspectorPortal.Common.Dtos.AuthenticationDtos
{

    //Data Transfer Object olarak tanımlanan sınıfımızda esasen veri tabanından alınan spesifik verilen kullanıcıya gönderilmesi işlemleri için açılır. Y
    public class AuthenticationLoginDto
    {
        public string Email { get; set; }
        public string Parola { get; set; }
    }


}