using InspectorPortal.Common.Dtos.GorevDtos;
using InspectorPortal.Common.Dtos.MufettisDtos;
using InspectorPortal.Common.Dtos.UniteBirimDtos;
using InspectorPortal.Data;
using InspectorPortal.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InspectorPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GorevController : ControllerBase
    {
        private readonly InspectorPortalDbContext DbContext;

        public GorevController(InspectorPortalDbContext dbContext)
        {
            DbContext = dbContext;
        }

        /* EKLEME */

        // TODO: ADD GOREV

        [HttpPost("add-gorev")]
        public IActionResult GorevTanımla([FromBody] AddGorev input)
        {
            var yeniGorev = new Gorev()
            {
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

        /* LİSTELEME */

        // LIST OF GOREVLER

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

        //TODO: GET GOREV BY ID

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

        // TODO: GET BIRIM BY ID IN GOREV

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

        /* GUNCELLEME */

        //TODO: UPDATE GOREV

        [HttpPost("update-gorev-by-Id")]
        public IActionResult UpdateGorev([FromForm] UpdateGorev updatedGorev)
        {
            if (updatedGorev.GorevId != 0)
            {
                var currentGorev = DbContext.Gorevler.FirstOrDefault(x => x.Id == updatedGorev.GorevId);
                var currentMufettisGorevler = DbContext.MufettisGorevler.Where(x => x.GorevID == updatedGorev.GorevId).ToList();

                if (currentGorev != null && currentMufettisGorevler != null)
                {
                    DbContext.MufettisGorevler.RemoveRange(currentMufettisGorevler);
                    foreach (var MufettisID in updatedGorev.MufettisIds)
                    {
                        DbContext.MufettisGorevler.Add(new MufettisGorev
                        {
                            GorevID = updatedGorev.GorevId,
                            MufettisID = MufettisID,
                        });
                    }
                    currentGorev.UnitID = updatedGorev.BirimId;
                    currentGorev.Konusu = updatedGorev.Konu;
                    currentGorev.VerilisTarihi = updatedGorev.GorevVerilisTarihi;
                    currentGorev.BaslamaTarihi = updatedGorev.GorevBaslangicTarihi;
                    currentGorev.BitisTarihi = updatedGorev.GorevBitisTarihi;
                    currentGorev.Durum = updatedGorev.Durum;

                    var result = DbContext.SaveChanges();
                    if (result > 0)
                    {

                        return Ok();
                    }

                }
            }
            return BadRequest();
        }

        /* SİLME */

        //TODO: DELETE GOREV

        [HttpDelete("delete-gorev/{gorevId}")]
        public IActionResult DeleteGorev([FromRoute] int gorevId)
        {
            var gorevRow = DbContext.Gorevler.FirstOrDefault(x=>x.Id == gorevId);
            var mufettisGorevler = DbContext.MufettisGorevler.Where(x => x.GorevID == gorevId).ToList();
            if (gorevRow != null)
            {
                DbContext.Gorevler.Remove(gorevRow);
                DbContext.MufettisGorevler.RemoveRange(mufettisGorevler);
                var result = DbContext.SaveChanges();
                if (result > 0)
                {

                    return Ok();
                }
            }

            return BadRequest();
        }
    }
}
