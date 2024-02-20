using Blockchain.Domain.Services;
using Microsoft.AspNetCore.Http;

namespace Blockchain.Infrastructure.Services
{
    public class HttpContextClaimsProvider : IClaimsProvider
    {
        public HttpContextClaimsProvider(IHttpContextAccessor httpContext)
        {
            var claims = httpContext?.HttpContext.User?.Claims;
            var name = claims?.Where(x => x.Type == "Name").FirstOrDefault()?.Value;
            var email = claims?.Where(x => x.Type == "Email").FirstOrDefault()?.Value;
            ClaimsPrinciple = new ClaimsPrinciple(name, email);
        }

        public ClaimsPrinciple ClaimsPrinciple { get; private set; }

    }
}
