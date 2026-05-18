using Core.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
        /// <summary>
        /// Salts the password and hashes it using SHA256. 
        /// WHy Salting Learn ?? : Salting is a technique used to enhance the security of password hashing.
        /// It involves adding a unique, random string (called a salt) to the password before hashing it.
        /// This makes it much more difficult for attackers to use precomputed hash tables (like rainbow tables) to crack passwords, as each password will have a different hash even if the same password is used by multiple users.
        /// Salting also helps protect against brute-force attacks, as attackers would need to compute the hash for each possible salt value, significantly increasing the time required to crack passwords.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public string HashPassword(string password, string salt)
        {
            string saltedPassword = password + salt;

            byte[] bytes = Encoding.UTF8.GetBytes(saltedPassword);

            byte[] hash = SHA256.HashData(bytes);

            return Convert.ToBase64String(hash);
        }
    }
}
