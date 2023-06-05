using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace EpiConnectAPI.Services.Security {
    public interface ITokenService {
        string GetToken(IdentityUser user, IList<Claim> roles);
    }
}
