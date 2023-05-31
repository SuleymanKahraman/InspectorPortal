using InspectorPortal.Common.Dtos.UniteBirimDtos;
using InspectorPortal.Data;
using InspectorPortal.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace InspectorPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UniteBirimController : ControllerBase
    {
        private readonly InspectorPortalDbContext DbContext;

        public UniteBirimController(InspectorPortalDbContext dbContext)
        {
            DbContext = dbContext;
        }

        // TODO: ADD UNITE

        [HttpPost("add-unite")]
        public IActionResult UniteTanimla([FromBody] AddUnit input)
        {
            var gmId = DbContext.UniteBirimler.First(x => x.Birim == "GENEL MUDURLUK").Id;
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

        // TODO: ADD BIRIM

        [HttpPost("add-birim")]
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

        /* LİSTELEME */

        // TODO: GET ALL UNITE WITH SORUMLU

        [HttpGet("list-unite-with-sorumlu")]

        public IActionResult GetListOfUnite()
        {

            var firstUniteId = DbContext.UniteBirimler.First(x => x.Birim == "GENEL MUDURLUK").Id;
            var result = DbContext.UniteBirimler
                                                .Where(x => x.BirimID == firstUniteId && x.Id != firstUniteId)
                                                .Select(x => new ListUniteWithSorumlu
                                                {
                                                    UniteID = x.Id,
                                                    Unite = x.Birim,
                                                    UniteSorumlusu = x.BirimSorumlusu,
                                                }).ToList();
            if (result != null)
            {
                return Ok(result);

            }
            return BadRequest();
        }

        // TODO: GET LIST OF UNITE

        [HttpGet("list-unite")]
        public IActionResult GetListOFUnite()
        {
            // UniteBirim.cs'de BirimID'si 53 (Genel Müdürlük satırı ID'si) olanlar Unite olacağından UniteBirimDto'daki fieldlara yerleştirilecektir. 
            //var gmId = DbContext.UniteBirimler.Where(x => x.Birim == "Genel Müdürlük").Select(x => x.Id).FirstOrDefault();
            var firstUniteId = DbContext.UniteBirimler.First(x => x.Birim == "GENEL MUDURLUK").Id;
            var result = DbContext.UniteBirimler
                                                    .Where(x => x.BirimID == firstUniteId && x.Id != firstUniteId)
                                                    .Select(x => new ListUniteOrBirim
                                                    {
                                                        Id = x.Id,
                                                        UniteOrBirim = x.Birim
                                                    }).ToList();
            if (result != null)
            {

                return Ok(result);

            }
            return BadRequest();

        }

        // TODO: GET UNITE BY ID

        [HttpGet("get-unite-by-id/{uniteId}")]
        public IActionResult GetUniteById([FromRoute] int uniteId)
        {
            var firstUniteId = DbContext.UniteBirimler.First(x => x.Birim == "GENEL MUDURLUK").Id;
            if (uniteId != firstUniteId)
            {
                var result = DbContext.UniteBirimler
                                                   .Where(x => x.Id == uniteId)
                                                   .Select(x => new ListUniteWithSorumlu
                                                   {
                                                       Unite = x.Birim,
                                                       UniteSorumlusu = x.BirimSorumlusu
                                                   }).SingleOrDefault();
                return Ok(result);

            }
            return Ok("Genel Müdürlük Birimleri Unitelerden Oluşmaktadır.");

        }


        //TODO: GET LIST OF BIRIM 

        [HttpGet("get-birim-by-id/{birimId}")]
        public IActionResult GetBirimById([FromRoute] int birimId)
        {
            var firstUniteId = DbContext.UniteBirimler.First(x => x.Birim == "GENEL MUDURLUK").Id;
            if (birimId != firstUniteId)
            {
                var result = DbContext.UniteBirimler
                                               .Where(x => x.BirimID == birimId)
                                               .Select(x => new ListUniteWithSorumlu
                                               {
                                                   UniteID = x.Id,
                                                   Unite = x.Birim,
                                                   UniteSorumlusu = x.BirimSorumlusu
                                               }).ToList();
                return Ok(result);

            }
            return Ok("Genel Müdürlük Birimleri Unitelerden Oluşmaktadır.");

        }

        //TODO: GET BIRIM SORUMLUSU

        [HttpGet("get-birimSorumlusu-by-id/{birimId}")]
        public IActionResult GetBirimSorumlusuById([FromRoute] int birimId)
        {
            // İlgili UstBirim seçildikten sonra UstBirime bağlı olan AltBirimler post edililir. 
            var result = DbContext.UniteBirimler
                                                .Where(x => x.Id == birimId)
                                                .Select(x => x.BirimSorumlusu).FirstOrDefault();
            return Ok(result);
        }


        /* GUNCELLEME */

        //TODO: UPDATE UNITE OR BIRIM

        [HttpPut("update-unite-birim-by-id/{uniteId}")]
        public IActionResult UpdateUniteOrBirim([FromRoute] int uniteId, [FromBody] UpdateUniteOrBirim update)
        {
            if (uniteId == 0)
            {
                return BadRequest();
            }
            else
            {
                var currentUniteOrBirim = DbContext.UniteBirimler.FirstOrDefault(x => x.Id == uniteId);
                if (currentUniteOrBirim != null)
                {
                    currentUniteOrBirim.Birim = update.UniteOrBirim;
                    currentUniteOrBirim.BirimSorumlusu = update.UniteOrBirimSorumlusu;
                    var result = DbContext.SaveChanges();
                    if (result > 0)
                    {
                        return Ok("Güncelleme İşlemi Başarılı!");
                    }
                }
            }
            return BadRequest();

        }

        /* SİLME */

        //TODO: DELETE UNITE OR BİRİM BY ID

        [HttpDelete("delete-by-id/{uniteId}")]

        public IActionResult DeleteUniteById([FromRoute] int uniteId)
        {
            var entities = DbContext.UniteBirimler.Where(x => x.Id == uniteId || x.BirimID == uniteId).ToList();
            DbContext.RemoveRange(entities);
            var result = DbContext.SaveChanges();
            if (result > 0)
            {
                return Ok("Silme İşlemi Başarılı");
            }
            return BadRequest();
        }

    }
}