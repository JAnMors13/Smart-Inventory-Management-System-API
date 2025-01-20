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
            throw new NotImplementedException();
        }
    }
}
