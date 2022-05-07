using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using APPoint.App.Models.Data;
using APPoint.App.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace APPoint.App.Services
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly AppSettings _appSettings;

        public TokenGenerator(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string GenerateRefreshToken()
        {
            var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));

            return token;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                { 
                    new Claim(ClaimTypes.Role, user.UserType.Type),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Surname, user.Surname),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
