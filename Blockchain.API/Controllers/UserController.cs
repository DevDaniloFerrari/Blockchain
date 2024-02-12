using Blockchain.Domain.Entities;
using Blockchain.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blockchain.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        [HttpPost(Name = "Create User")]
        public async Task<Guid> Create([FromServices] IUserService service, [FromBody] string name)
        {
            var user = new User(name);
            return await service.Create(user);
        }
    }
}