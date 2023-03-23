using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjectAPI.Provider
{
    public class DefaultPasswordHashProvider : IPasswordHashProvider
    {

        public string Hash(string password)
        {
            byte[] hash;
            byte[] payload = Encoding.UTF8.GetBytes(password);
            hash = SHA512.HashData(payload);
            return hash.ToString();
        }

        public bool Verify(string password, string hash)
        {
            string givenPasswordHash = this.Hash(password);

            if (givenPasswordHash.Equals(hash)) { 
                return true;
            }

            return false;
        }
    }
}
