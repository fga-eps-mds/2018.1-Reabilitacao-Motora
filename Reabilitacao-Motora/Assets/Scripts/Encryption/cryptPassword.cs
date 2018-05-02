using bcrypt;
using aes256;
using sha_256;
using sha_512;
using pepper;
using UnityEngine;

namespace cryptpw 
{
   public class cryptPassword
   {
       public string encrypt(string password, string username)
       {
           password = SHA_256.GenerateSHA256String(password);
           password += username;
           string mySalt = BCrypt.GenerateSalt();
           string myHash = BCrypt.HashPassword(password, mySalt);
           string result = mySalt + AES256.AES_Encrypt(myHash.Substring(29, myHash.Length - 29)) + Pepper.Generate();
           result = mySalt + SHA_512.GenerateSHA512String(result);
           return result;
       }

       public bool uncrypt(string password, string hash, string username)
       {
           password = SHA_256.GenerateSHA256String(password);
           password += username;
           password = BCrypt.HashPassword(password, hash);
           string salt = password.Substring(0, 29);
           password = salt + AES256.AES_Encrypt(password.Substring(29, password.Length - 29));
           bool doesPasswordMatch = Pepper.Check(password, hash, salt);
           return doesPasswordMatch;
       }
   }
}