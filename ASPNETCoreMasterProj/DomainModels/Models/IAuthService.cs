using System.Collections.Generic;
using System.Security.Claims;

namespace Repositories.Models
{
    public interface IAuthService
    {
        //public string SecretKey { get; set; }
        //public bool IsTokenValid(string token);
        //public string GenerateToken(IAuthContainerModel model);
        IEnumerable<Claim> GetTokenClaims(string token);
    }
}
