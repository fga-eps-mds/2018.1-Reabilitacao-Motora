using UnityEngine;
using System.Collections;
using bcrypt;
using sha_256;

namespace cryptpw 
{
   public class cryptPassword
   {
       public string encrypt(string password, string username)
       {
            password = SHA_256.GenerateSHA256String(password);

            string mySalt = BCrypt.GenerateSalt();
            password += username;
            string myHash = BCrypt.HashPassword(password, mySalt);

            return myHash;
       }

       public bool uncrypt(string password, string hash, string username)
       {
            password = SHA_256.GenerateSHA256String(password);

            password += username;

            bool doesPasswordMatch = BCrypt.CheckPassword(password, hash);

            return doesPasswordMatch;
       }
   }
}