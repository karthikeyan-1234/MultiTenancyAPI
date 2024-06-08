using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoApplicationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "JWTBearer")]
    public class WeatherForecastController : ControllerBase
    {
        AppDBContext dbContext;

        public WeatherForecastController(AppDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet(Name = "Test")]
        public IActionResult Test()
        {
            return Ok(dbContext.TestTables.ToList());
        }
    }
}