using System.Security.Cryptography;

namespace SecurePassword
{
    internal class AddPasswordToDBBase
    {
        public static byte[] ComputeHash(string password, byte[] salt, int iterations = HasingIterationsCount,
            int hashByteSize = HashByteSize)
        {
            using (Rfc2898DeriveBytes hashGenerator = new Rfc2898DeriveBytes(password, salt))
            {
                hashGenerator.IterationCount = iterations;
                return hashGenerator.GetBytes(hashByteSize);
            }
        }
    }
}