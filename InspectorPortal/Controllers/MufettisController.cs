using InspectorPortal.Common.Dtos.MufettisDtos;
using InspectorPortal.Data;
using InspectorPortal.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InspectorPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MufettisController : ControllerBase
    {
        private readonly InspectorPortalDbContext dbContext;

        public MufettisController(InspectorPortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // TODO: LIST OF MUFETTIS

        [HttpGet("list-mufettisler")]
        public IActionResult ListAllMufettis()
        {
            var mufettisler = dbContext.Mufettisler.Select(x => new ListAllMufettis
            {
                MufettisId = x.Id,
                Isim = x.Isim,
                Soyisim = x.Soyisim,
                KurumSicilNo = x.KurumSicilNo,
                Unvan = x.Unvan,
            }).ToList();

            if (mufettisler != null)
            {
                return Ok(mufettisler);
            }
            return BadRequest();
        }

        [HttpGet("list-mufettis-by-Id/{mufettisId}")]
        public IActionResult ListMufettisById([FromRoute] int mufettisId)
        {
            var mufettisRow = dbContext.Mufettisler.Where(x => x.Id == mufettisId).Select(x => new ListOfMufettisById
            {
                Isim = x.Isim,
                Soyisim = x.Soyisim,
                Email = x.Email,
                TcNo = x.TcNo,
                KurumSicilNo = x.KurumSicilNo,
                MufettisNo = x.MufettisNo,
                Unvan = x.Unvan,
                CalismaDurumu = x.CalismaDurumu,
                Telefon = x.Telefon,
                Adres = x.Adres,
                Photo = x.Photo != null ? Convert.ToBase64String(x.Photo) : null
            }).SingleOrDefault();
            if (mufettisRow != null)
            {
                return Ok(mufettisRow);
            }
            return Ok("Müfettiş Bilgileri Mevcut Değil!!!");
        }

        [HttpGet("get-photo-by-id/{mufettisId}")]

        // TODO: ADD MUFETTIS

        [HttpPost("add-mufettis")]
        public IActionResult AddNewMufettis([FromForm] AddNewMufettis mufettis)
        {
            byte[] resimBytes = null;
            if(mufettis.Photo != null)
            {
                var photo = mufettis.Photo;
                using (MemoryStream ms = new MemoryStream())
                {
                    photo.CopyTo(ms);
                    resimBytes = ms.ToArray();
                }
            }
            var addNewMufettisEntity = new Mufettis()
            {
                Isim = mufettis.Isim,
                Soyisim = mufettis.Soyisim,
                Email = mufettis.Email,
                TcNo = mufettis.TcNo,
                KurumSicilNo = mufettis.KurumSicilNo,
                MufettisNo = mufettis.MufettisNo,
                Unvan = mufettis.Unvan,
                CalismaDurumu = mufettis.CalismaDurumu,
                Telefon = mufettis.Telefon,
                Adres = mufettis.Adres,
                Photo = resimBytes,
            };

            if (addNewMufettisEntity != null)
            {
                dbContext.Mufettisler.Add(addNewMufettisEntity);
                dbContext.SaveChanges();
                return Ok("Kaydetme İşlemi Başarılı!!!");
            }

            return BadRequest();
        }

        // TODO: DELETE MUFETTIS BY ID

        [HttpDelete("delete-mufettis/{mufettisId}")]
        public IActionResult DeleteMufettisById([FromRoute] int mufettisId)
        {
            var mufettisRow = dbContext.Mufettisler.FirstOrDefault(x => x.Id == mufettisId);

            if (mufettisRow != null)
            {
                dbContext.Mufettisler.Remove(mufettisRow);
                var result = dbContext.SaveChanges();
                if (result > 0)
                {
                    return Ok("Silme İşlemi Başarılı");
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return Ok("Mufettiş Mevcut Değil!");
            }
        }

        // TODO: UPDATE MUFETTİS BY ID

        [HttpPut("update-mufettis/{mufettisId}")]
        public IActionResult UpdateMufettisById([FromRoute] int mufettisId, [FromForm] UpdateMufettis mft)
        {
            if (mufettisId == 0)
            {
                return BadRequest();
            }
            else
            {
                var currentMufettis = dbContext.Mufettisler.FirstOrDefault(x => x.Id == mufettisId);
                if (currentMufettis != null)
                {
                    currentMufettis.Isim = mft.Isim;
                    currentMufettis.Soyisim = mft.Soyisim;
                    currentMufettis.Email = mft.Email;
                    currentMufettis.TcNo = mft.TcNo;
                    currentMufettis.KurumSicilNo = mft.KurumSicilNo;
                    currentMufettis.MufettisNo = mft.MufettisNo;
                    currentMufettis.Unvan = mft.Unvan;
                    currentMufettis.CalismaDurumu = mft.CalismaDurumu;
                    currentMufettis.Telefon = mft.Telefon;
                    currentMufettis.Adres = mft.Adres;
                    if (mft.Photo is not null)
                    {
                        byte[] resimBytes;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            mft.Photo.CopyTo(ms);
                            resimBytes = ms.ToArray();
                        }
                        currentMufettis.Photo = resimBytes;
                    }
                    else
                    {
                        currentMufettis.Photo = null;
                    }
                    var result = dbContext.SaveChanges();
                    if (result > 0)
                    {
                        return Ok("Güncelleme İşlemi Başarılı");
                    }
                };
            }

            return BadRequest();
        }
    }
}