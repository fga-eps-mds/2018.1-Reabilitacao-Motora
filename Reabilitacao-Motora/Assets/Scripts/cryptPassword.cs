using bcrypt;

namespace cryptpw 
{
    public class cryptPassword 
    {
        public string encrypt(string password)
        {
            string mySalt = BCrypt.GenerateSalt();
            string myHash = BCrypt.HashPassword(password, mySalt);
            
            return myHash;
        }

        public bool uncrypt(string password, string hash)
        {
            bool doesPasswordMatch = BCrypt.CheckPassword(password, hash);

            return doesPasswordMatch;
        }
    }
}