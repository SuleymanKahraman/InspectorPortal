using InspectorPortal.Common.Dtos;
using InspectorPortal.Common.Dtos.AuthenticationDtos;
using InspectorPortal.Data;
using InspectorPortal.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace InspectorPortal.Controllers
{
    // api yazmasak da olur. 
    // AuthenticationController'daki amaç Login işlemidir. 
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        //DbContext sınıfı controller yapıcı metoduna atanır. 
        private readonly InspectorPortalDbContext dbContext;

        public AuthenticationController(InspectorPortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        // TODO: LOGIN
        //Login işlemi bir post işlemidir. Attribute'de parantez içinde action'a ulaşabilmek için isim verilebilir. 
        [HttpPost("login")]

        // AuthenticationRequestDto sınıfından bir örnek alınır. Amaç ajax ile gönderilen postların bu sınıfta tutulmasıdır. Burada tutulan postlar/datalar daha sonrasında Action metodu içinde işlenir. İşlenen veriler daha sonrasında usera gönderilmek istenirse response'un içine istenilen veri enjekte edilip gönderilir. 
        public IActionResult Login([FromBody] AuthenticationLoginDto login)
        {
            var loginResultEntity = dbContext.Kullanicilar.Where(x => x.Email == login.Email && x.Parola == login.Parola)
                  .Select(x => new AuthenticationResultDto
                  {
                      KullaniciID = x.Id,
                      Isim = x.Isim,
                      Soyisim = x.Soyisim,
                      Unvan = x.Unvan,

                  }).FirstOrDefault();

            if (loginResultEntity != null)
            {
                var mufettisID = dbContext.Mufettisler.First(x => x.Email == login.Email).Id;
                var token = GetJwtToken(loginResultEntity.KullaniciID);
                loginResultEntity.Token = token;
                loginResultEntity.MufettisID = mufettisID <= 0 ? mufettisID : 0;
                return Ok(loginResultEntity);
            }

            return BadRequest();
        }


        // TODO: SIGN-UP
        [HttpPost("sign-up")]

        // AuthenticationRequestDto sınıfından bir örnek alınır. Amaç ajax ile gönderilen postların bu sınıfta tutulmasıdır. Burada tutulan postlar/datalar daha sonrasında Action metodu içinde işlenir. İşlenen veriler daha sonrasında usera gönderilmek istenirse response'un içine istenilen veri enjekte edilip gönderilir. 
        public IActionResult SignUp([FromBody] AuthenticationSignUpDto signup)
        {

            var SignUpEntity = new Kullanici()
            {
                Isim = signup.Isim,
                Soyisim = signup.Soyisim,
                Email = signup.Email,
                Unvan = signup.Unvan,
                Parola = signup.Parola

            };

            if (signup != null)
            {
                dbContext.Kullanicilar.Add(SignUpEntity);
                dbContext.SaveChanges();
                return Ok("Kaydetme Başarılı");
            }

            return BadRequest();
            //TODO: handle
        }

        //TODO: GetJwtToken
        private string GetJwtToken(int userId)
        {
            var claims = new Dictionary<string, object>
            {
                { "UserId", userId },
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hava ne kadar guzel!")),
                                                            SecurityAlgorithms.HmacSha256Signature),
                Claims = claims,
                //IssuedAt = DateTime.Now,
                //NotBefore = DateTime.Now
            };

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
}
