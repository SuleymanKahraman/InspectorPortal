using InspectorPortal.Common.Dtos;
using InspectorPortal.Data;
using InspectorPortal.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

            //var gmId = DbContext.UniteBirimler.Where(x => x.Birim == "Genel Müdürlük").Select(x => x.Id).FirstOrDefault();
            var gmId = DbContext.UniteBirimler.First(x => x.Birim == "Genel Müdürlük").Id;
            var result = DbContext.UniteBirimler.Where(x => x.BirimID == gmId).Select(x => new Option { Id = x.Id, label = x.Birim }).ToList();

            //var UstBirimler = DbContext.UniteBirimler.Where(x => x.BirimID == gmId).Select(x=> new { x.Id, x.Birim, x.BirimSorumlusu });
            return Ok(result);
        }
        [HttpGet("birimSorumlusu/{birimId}")]
        public IActionResult UniteBirim([FromRoute] int birimId)
        {
            // İlgili UstBirim seçildikten sonra UstBirime bağlı olan AltBirimler post edililir. 
            var result = DbContext.UniteBirimler.Where(x => x.Id == birimId).Select(x => x.BirimSorumlusu).FirstOrDefault();
            return Ok(result);
        }


        [HttpPost("uniteTanimla")]
        public IActionResult UniteTanimla([FromBody] AddUnit input)
        {
            var gmId = DbContext.UniteBirimler.First(x => x.Birim == "Genel Müdürlük").Id;
            var entity = new UniteBirim()
            {
                Birim = input.UniteAdi,
                BirimSorumlusu = input.UniteSorumlusu,
                BirimID = gmId

            };
            if (entity != null)
            {

                DbContext.UniteBirimler.Add(entity);
                DbContext.SaveChanges();
                return Ok("Kaydetme İşlemi Başarılı!!!");

            }
            else
            {
                return BadRequest();
            }


        }

        [HttpPost("birimTanimla")]
        public IActionResult BirimTanimla([FromBody] AddBirim input)
        {
            var entity = new UniteBirim()
            {
                Birim = input.BirimAdi,
                BirimSorumlusu = input.BirimSorumlusu,
                BirimID = input.BirimID

            };
            if (entity != null)
            {

                DbContext.UniteBirimler.Add(entity);
                DbContext.SaveChanges();
                return Ok("Kaydetme İşlemi Başarılı!!!");

            }
            else
            {
                return BadRequest();
            }


        }
    }
}