using CryptoHelper;

namespace server.Services {
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password) {
            return Crypto.HashPassword(password);
        }

        // Verify the password hash against the given password
        public bool VerifyPassword(string hash, string password) {
            return Crypto.VerifyHashedPassword(hash, password);
        }
    }
}