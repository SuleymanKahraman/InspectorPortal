using InspectorPortal.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InspectorPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly InspectorPortalDbContext dbContext;

        public AuthenticationController(InspectorPortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost("login")]
        public IActionResult Login()
        {
            //TODO: handle
            return Ok("Çalıştı");
        }
    }
}
