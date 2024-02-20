using Blockchain.Domain.Requests;
using Blockchain.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blockchain.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class WalletController : ControllerBase
    {

        [HttpPost(Name = "Send Money")]
        public IActionResult SendMoney([FromServices] IWalletService service, [FromBody] SendMoneyRequest request)
        {
            try
            {
                service.SendMoney(request.From, request.To, request.Amount);
                return Ok(new { status = 200, message = "Transaction sent and will be processed" });

            }
            catch (Exception ex)
            {
                return Ok(new { status = 500, message = ex.Message });
            }
            
        }
    }
}