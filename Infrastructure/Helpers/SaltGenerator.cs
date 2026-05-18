using System.Security.Cryptography;

namespace Infrastructure.Helpers
{
    public static class SaltGenerator
    {
        public static string GenerateSalt()
        {
            byte[] saltBytes = RandomNumberGenerator.GetBytes(32);

            return Convert.ToBase64String(saltBytes);
        }
    }
}
