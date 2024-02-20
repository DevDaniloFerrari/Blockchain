using Blockchain.Domain.Entities;
using Blockchain.Domain.Requests;
using Blockchain.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blockchain.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        [HttpPost]
        public IActionResult Create([FromServices] IUserService service, [FromBody] CreateUserRequest request)
        {
            try
            {
                var user = new User(request.Name, request.Email);
                var userId = service.Create(user, request.Password);
                return Ok(new { status = 200, message = $"User created successfully. Id: {userId}" });
            }
            catch (Exception ex)
            {
                return Ok(new { status = 500, message = ex.Message });
            }
        }

        [HttpPost("Login")]
        public IActionResult Authenticate([FromServices] IUserService service, [FromBody] AuthenticateUserRequest request)
        {
            try
            {
                var token = service.Authenticate(request.Email, request.Password);
                return Ok(new { status = 200, data = token, message = "Successfully authenticated" });

            }
            catch (Exception ex)
            {
                return Ok(new { status = 500, message = ex.Message });
            }
        }
    }
}