using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace APPoint.App.Services
{
    public class CryptographyService : ICryptographyService
    {
        public string Hash(string password, string salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.UTF8.GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
        }
    }
}
