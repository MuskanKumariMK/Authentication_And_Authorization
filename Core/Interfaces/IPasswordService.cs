namespace Core.Interfaces
{
    public interface IPasswordService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hash);
        string HashPassword(string password, string salt);
    }
}
