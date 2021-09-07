using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace F1_time_tracking
{
    class PasswordFunctions
    {
        public string PasswordHasher(string Password, string salt)
        {
            int Hasing_interations = 1000;
            // in Production the Argn2 Crythographie would be implemented, because we have no internet connection the library can't be installed. And a pepper w
            SHA512 sha256Hash = SHA512.Create();
            HashAlgorithm hashAlgorithm = sha256Hash;
            string PasswordWithHash = Password + salt;

            string result = null;
            for(int i = Hasing_interations; i >= 0; i-- )
            {
                
                result = Convert.ToBase64String(hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(PasswordWithHash)));
            }
            
            

            return result;
        }

        public string SaltGenerator()
        {
            var rng = RandomNumberGenerator.Create();

            //generate 128 Bit alt using PRNG
            byte[] salt = new byte[256 / 8];

            rng.GetBytes(salt);
            return Convert.ToBase64String(salt);

            
        }

        public bool verifyHashes(string DbHash, string InputHash)
        {
            if (DbHash.Equals(InputHash))
                return true;
            else
                return false;
            
        }
    }
}
