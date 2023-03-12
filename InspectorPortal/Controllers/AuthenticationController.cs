using InspectorPortal.Common.Dtos;
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
        public IActionResult Login([FromBody] AuthenticationRequestDto input)
        {
            var entity = dbContext.Users.FirstOrDefault(x=>x.Email == input.Email && x.Password == input.Password);
            if(entity != null)
            {
                return Ok(entity.FirstName);
            }
            return BadRequest();
            //TODO: handle
        }
    }
}
