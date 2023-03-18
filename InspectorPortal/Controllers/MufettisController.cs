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

        [HttpPost("mufettis")]
        public IActionResult Mufettis([FromBody] Mufettis mufettis)
        {

            return Ok();
        }
    }
}
