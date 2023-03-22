using InspectorPortal.Data;
using InspectorPortal.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InspectorPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MufettisController : ControllerBase
    {
        private readonly InspectorPortalDbContext dbContext;

        public MufettisController(InspectorPortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet("mufettis")]
        public IActionResult Mufettis() 
        {
            var mufettisList = dbContext.Mufettisler.Select(p=> new {p.Id,p.KurumSicilNo,p.Isim,p.Soyisim}).ToList();
            return Ok(mufettisList);
        }

        [HttpPost("mufettis")]
        public IActionResult Mufettis([FromBody] Mufettis mufettis)
        {
            if(mufettis != null) {
                dbContext.Mufettisler.Add(mufettis);
                dbContext.SaveChanges();
                return Ok("Kaydetme İşlemi Başarılı!!!");
            }
            else
            {
                return BadRequest();
            }
            
        }
    }
}
