using Microsoft.AspNetCore.Mvc;

namespace Blockchain.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        [HttpPost(Name = "GetWeatherForecast")]
        public IEnumerable<string> Create()
        {
           //Create user
           return new List<string>();
        }
    }
}