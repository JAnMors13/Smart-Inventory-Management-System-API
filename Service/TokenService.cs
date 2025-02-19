using Microsoft.IdentityModel.Tokens;
using Smart_Inventory_Management_System.Interface;
using Smart_Inventory_Management_System.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
            new Claim(JwtRegisteredClaimNames.Sub, AppUser.Id),
            new Claim(ClaimTypes.NameIdentifier, AppUser.Id),
            new Claim(JwtRegisteredClaimNames.Email, AppUser.Email),
            new Claim(JwtRegisteredClaimNames.GivenName, AppUser.UserName),
            new Claim("PhoneNumber", AppUser.PhoneNumber ?? string.Empty),
            new Claim(ClaimTypes.Role, AppUser.Role.ToString()) // ✅ Add Role
        };

        var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = credentials,
            Issuer = _config["JWT:Issuer"],
            Audience = _config["JWT:Audience"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }


}
