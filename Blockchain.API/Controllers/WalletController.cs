using Blockchain.Domain.Requests;
using Blockchain.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blockchain.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalletController : ControllerBase
    {

        [HttpPost(Name = "Send Money")]
        public IActionResult SendMoney([FromServices] IWalletService service, [FromBody] SendMoneyRequest request)
        {
            service.SendMoney(request.From, request.To, request.Amout);
            return Ok();
        }
    }
}