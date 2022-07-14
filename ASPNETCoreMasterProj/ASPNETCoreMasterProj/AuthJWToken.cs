using Repositories.Data;
using Repositories.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Repositories
{
    public class AuthJWToken : IAuthJWToken
    {
        private readonly IOptions<Authentication> _options;

        public AuthJWToken(IOptions<Authentication> options)
        {
            _options = options;
        }
        public string CreateJWToken(string username, string password)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = _options.Value.JWT.SecurityKey;
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1), 
                SigningCredentials = new SigningCredentials( 
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenKey)), 
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
