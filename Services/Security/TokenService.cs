using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EpiConnectAPI.Services.Security {
    public class TokenService : ITokenService {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration) {
            _configuration = configuration;
        }
        public string GetToken(IdentityUser user, IList<Claim> roles) {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtBearerTokenSettings:SecretKey"]));
            var signingCredential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.Email)
            };

            claims.AddRange(roles);

            var TokenOptions = new JwtSecurityToken(
                    issuer: _configuration["JwtBearerTokenSettings:Issuer"],
                    audience: _configuration["JwtBearerTokenSettings:Audience"],
                    claims: claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtBearerTokenSettings:ExpireTime"])),
                    signingCredentials: signingCredential
                );
            return new JwtSecurityTokenHandler().WriteToken(TokenOptions);
        }
    }
}
