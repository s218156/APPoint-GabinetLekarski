using System;
namespace APPoint.App.Services
{
    public interface ICryptographyService
    {
        string Hash(string password, string salt);
        string GenerateSalt();
    }
}
