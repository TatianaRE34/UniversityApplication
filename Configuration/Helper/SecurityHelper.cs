using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Helper
{
    public class SecurityHelper
    { 
        public string CreateSalt(int size)
        {
            var randaomNumberGenerator= new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff= new byte[size];
            randaomNumberGenerator.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        public string GenerateSHA256Hash(String input, String Salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + Salt);
            System.Security.Cryptography.SHA256Managed sha256HashDtring =
                new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256HashDtring.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
