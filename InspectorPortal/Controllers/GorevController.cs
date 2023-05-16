using InspectorPortal.Common.Dtos.UniteBirimDtos;
using InspectorPortal.Common.Enums;
using InspectorPortal.Data;
using InspectorPortal.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InspectorPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GorevController : ControllerBase
    {
        private readonly InspectorPortalDbContext DbContext;

        public GorevController(InspectorPortalDbContext dbContext)
        {
            DbContext = dbContext;
        }

        [HttpPost("add-gorev")]
        public IActionResult GorevTanımla([FromBody] AddGorev input)
        {
            var yeniGorev = new Gorev()
            {
                GorevTipi = GorevTipi.PeriyodikTeftis,
                Konusu = input.Konu,
                UnitID = input.BirimId,
                VerilisTarihi = input.GorevVerilisTarihi,
                BaslamaTarihi = input.GorevBaslangicTarihi,
                BitisTarihi = input.GorevBitisTarihi,
                Durum = true,
            };
            DbContext.Gorevler.Add(yeniGorev);
            var result = DbContext.SaveChanges();
            if (result > 0)
            {
                var newInserted = DbContext.Gorevler.Select(x => x.Id).OrderByDescending(x => x).FirstOrDefault();
                if (newInserted != 0)
                {
                    foreach (var mufettisId in input.MufettisIds)
                    {
                        var newMapping = new MufettisGorev { GorevID = newInserted, MufettisID = mufettisId };
                        DbContext.MufettisGorevler.Add(newMapping);
                    }
                }
                DbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("list-gorevler")]
        public IActionResult ListGorev([FromBody] GorevFilter filter)
        {
            var result = DbContext.Gorevler.Select(x => new ListAllGorev
            {
                BaslangicTarihi = x.BaslamaTarihi.ToString("dd/MM/yyyy"),
                BirimAdi = $"{x.UniteBirim.UstBirim.Birim} / {x.UniteBirim.Birim}",
                BitisTarihi = x.BitisTarihi.ToString("dd/MM/yyyy"),
                GorevId = x.Id,
                Konu = x.Konusu,
                BirimId = x.UnitID
            }).ToList();
            foreach (var gorev in result)
            {
                var gorevliMufettisler = DbContext.MufettisGorevler.Where(x => x.GorevID == gorev.GorevId).Select(x => $"{x.Mufettis.Isim} {x.Mufettis.Soyisim}").ToList();
                gorev.GorevliMufettisler = gorevliMufettisler;
            }
            if(filter.MufettisAdi is not null)
            {
                result = result.Where(x=>x.GorevliMufettisler.Contains(filter.MufettisAdi)).ToList();
            }
            if (filter.BirimId is not null)
            {
                result = result.Where(x => x.BirimId == filter.BirimId).ToList();
            }
            return Ok(result);
        }
    }
}