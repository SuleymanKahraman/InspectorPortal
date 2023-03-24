using InspectorPortal.Common.Dtos;
using InspectorPortal.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InspectorPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UniteBirimController : ControllerBase
    {
        private readonly InspectorPortalDbContext DbContext;

        public UniteBirimController(InspectorPortalDbContext dbContext)
        {
            DbContext = dbContext;
        }

        [HttpGet("uniteBirim")]
        public IActionResult UniteBirim()
        {

            // UniteBirim.cs'de BirimID'si 53 (Genel Müdürlük satırı ID'si) olanlar Unite olacağından UniteBirimDto'daki fieldlara yerleştirilecektir. 

            var gmId = DbContext.UniteBirimler.Where(x => x.Birim == "Genel Müdürlük").Select(x => x.Id).FirstOrDefault();
            var UstBirimler = DbContext.UniteBirimler.Where(x => x.BirimID == gmId).ToList();
            return Ok(UstBirimler);
        }
        [HttpPost("uniteBirim")]
        public IActionResult UniteBirim(string birim)
        {
            // İlgili UstBirim seçildikten sonra UstBirime bağlı olan AltBirimler post edililir. 

            var Id = DbContext.UniteBirimler.Where(x => x.Birim == birim).Select(x => x.Id).FirstOrDefault();
            var Birimler = DbContext.UniteBirimler.Where(x => x.BirimID == Id).Select(x => x.Birim).ToList();
            return Ok(Birimler);
        }
    }
}
