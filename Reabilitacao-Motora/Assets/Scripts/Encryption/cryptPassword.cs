using bcrypt;
using aes256;
using sha_256;

namespace cryptpw 
{
    public class cryptPassword 
    {
        public string encrypt(string password)
        {
            password = SHA_256.GenerateSHA256String(password);
 
            string mySalt = BCrypt.GenerateSalt();
            string myHash = BCrypt.HashPassword(password, mySalt);

            return myHash;
        }

        public bool uncrypt(string password, string hash)
        {
            password = SHA_256.GenerateSHA256String(password);

            bool doesPasswordMatch = BCrypt.CheckPassword(password, hash);

            return doesPasswordMatch;
        }
    }
}

