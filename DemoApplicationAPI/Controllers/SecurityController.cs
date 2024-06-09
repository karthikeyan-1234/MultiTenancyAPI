using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        ISQLSecurity security;

        public SecurityController(ISQLSecurity security)
        {
            this.security = security;
        }

        [HttpPost("encrypt")]
        public IActionResult EncryptConnectionString(string connectionString)
        {
            return Ok(security.EncryptConnection(connectionString));
        }

        [HttpPost("decrypt")]
        public IActionResult DecryptConnectionString(string encryptedString)
        {
            return Ok(security.DecryptConnection(encryptedString));
        }

    }
}
