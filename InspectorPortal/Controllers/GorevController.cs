using InspectorPortal.Common.Dtos.GorevDtos;
using InspectorPortal.Common.Dtos.MufettisDtos;
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

        // GOREV EKLEME

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

        // GOREV LİSTELEME

        [HttpPost("list-gorevler")]
        public IActionResult ListGorev([FromBody] GorevFilter filter)
        {
            // Bir görevin birden fazla müfettişi olabilir. Bu nedenle görevleri listelerken ayrıca
            // List<string> tipinde görevliMüfettişleri de düzenlemeliyiz. 

            var result = DbContext.Gorevler.Select(x => new ListAllGorev
            {
                BaslangicTarihi = x.BaslamaTarihi.ToString("dd/MM/yyyy"),
                BirimAdi = $"{x.UniteBirim.UstBirim.Birim} / {x.UniteBirim.Birim}",
                BitisTarihi = x.BitisTarihi.ToString("dd/MM/yyyy"),
                GorevId = x.Id,
                Konu = x.Konusu,
                BirimId = x.UnitID
            }).ToList();

            // Database'de görevler öncelikle ListAllGorev Dtos'a atanır. Ardından  MufettisGorev Tablosundan Göreve atanmış müfettişler bulunur ve List tipindeki değere atanır. 
            foreach (var gorev in result)
            {
                var gorevliMufettisler = DbContext.MufettisGorevler.Where(x => x.GorevID == gorev.GorevId).Select(x => $"{x.Mufettis.Isim} {x.Mufettis.Soyisim}").ToList();
                gorev.GorevliMufettisler = gorevliMufettisler;
            }
            if (filter.MufettisAdi is not null)
            {
                result = result.Where(x => x.GorevliMufettisler.Contains(filter.MufettisAdi)).ToList();
            }
            if (filter.BirimId is not null)
            {
                result = result.Where(x => x.BirimId == filter.BirimId).ToList();
            }
            return Ok(result);
        }

        [HttpGet("get-gorev-by-Id/{gorevId}")]
        public IActionResult ListGorevById([FromRoute] int gorevId)
        {
            var gorevliMufettisler = DbContext.MufettisGorevler.Where(x => x.GorevID == gorevId).Select(x => $" {x.Mufettis.Isim} {x.Mufettis.Soyisim} ({x.Mufettis.Unvan})").ToList();


            if (gorevliMufettisler != null)
            {
                var result = DbContext.Gorevler.Where(x => x.Id == gorevId).Select(x => new ListOfGorevById
                {
                    BirimId = x.UnitID,
                    BirimAdi = x.UniteBirim.Birim,
                    Konu = x.Konusu,
                    GorevliMufettisler = gorevliMufettisler,
                    VerilisTarihi = x.VerilisTarihi,
                    BaslamaTarihi = x.BaslamaTarihi,
                    BitisTarihi = x.BitisTarihi,
                    Durum = x.Durum,

                }).ToList();

                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("get-birim-by-Id/{birimId}")]
        public IActionResult GetBirims([FromRoute] int birimId)
        {
            var ustbirimId = DbContext.UniteBirimler.FirstOrDefault(x => x.Id == birimId).BirimID;
            var birimler = DbContext.UniteBirimler.Where(x => x.BirimID == ustbirimId).Select(x => new ListUniteOrBirim
            {
                Id = x.Id,
                UniteOrBirim = x.Birim,
            }).ToList();
            if (birimler != null) { return Ok(birimler); }
            return BadRequest();
        }
    }
}
