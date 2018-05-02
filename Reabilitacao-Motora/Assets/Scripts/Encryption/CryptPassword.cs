using bcrypt;
using aes256;
using sha_256;
using sha_512;
using pepper;
using UnityEngine;

namespace cryptpw 
{
   public class CryptPassword
   {
       public static string Encrypt(string password, string username)
       {
           string hashedPassword = SHA_256.GenerateSHA256String(password);
           string nounced = hashedPassword + username;
           string mySalt = BCrypt.GenerateSalt();
           string myHash = BCrypt.HashPassword(nounced, mySalt);
           string result = mySalt + AES256.AES_Encrypt(myHash.Substring(29, myHash.Length - 29)) + Pepper.Generate();
           result = mySalt + SHA_512.GenerateSHA512String(result);
           return result;
       }

       public static bool Uncrypt(string password, string hash, string username)
       {
           string hashedPassword = SHA_256.GenerateSHA256String(password);
           string nounced = hashedPassword + username;
           string myHash = BCrypt.HashPassword(nounced, hash);
           string mySalt = myHash.Substring(0, 29);
           string result = mySalt + AES256.AES_Encrypt(myHash.Substring(29, myHash.Length - 29));
           bool doesPasswordMatch = Pepper.Check(result, hash, mySalt);
           return doesPasswordMatch;
       }
   }
}