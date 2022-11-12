using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecurePassword
{
    //Step 1: Generate randome long salt
    //step 2: Add this to the password
    //Step 3: Hash both salt and code
    //Step 4: store in DB

    internal class AddPasswordToDB
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
