using Microsoft.IdentityModel.Tokens;
using Smart_Inventory_Management_System.Interface;
using Smart_Inventory_Management_System.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Smart_Inventory_Management_System.Repository
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key; 
        public TokenService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));

        }

        public string CreateToken(AppUser AppUser)
        {
            var claims = new List<Claim>
            {
                    new Claim(JwtRegisteredClaimNames.Email, AppUser.Email),
                    new Claim(JwtRegisteredClaimNames.GivenName, AppUser.UserName),
                    new Claim("PhoneNumber", AppUser.PhoneNumber ?? string.Empty)
            };

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
