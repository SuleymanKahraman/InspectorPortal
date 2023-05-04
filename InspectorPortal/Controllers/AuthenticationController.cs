using InspectorPortal.Common.Dtos;
using InspectorPortal.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        //Login işlemi bir post işlemidir. Attribute'de parantez içinde action'a ulaşabilmek için isim verilebilir. 
        [HttpPost("login")]

        // AuthenticationRequestDto sınıfından bir örnek alınır. Amaç ajax ile gönderilen postların bu sınıfta tutulmasıdır. Burada tutulan postlar/datalar daha sonrasında Action metodu içinde işlenir. İşlenen veriler daha sonrasında usera gönderilmek istenirse response'un içine istenilen veri enjekte edilip gönderilir. 
        public IActionResult Login([FromBody] AuthenticationRequestDto input)
        {
            //var entity = dbContext.Mufettisler.FirstOrDefault(x => x.Email == input.Email && x.Sifre == input.Sifre);
            //if (entity != null)
            //{
            //    return Ok(entity);
            //}
            return Ok();
            //TODO: handle
        }
    }
}
