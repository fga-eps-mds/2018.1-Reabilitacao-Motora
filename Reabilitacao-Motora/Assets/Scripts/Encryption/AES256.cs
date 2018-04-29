using System;
using System.Text;
using System.Security.Cryptography;

namespace aes256
{
    public class AES256 
    {
        public static string AES_Encrypt (string text) {
            AesCryptoServiceProvider crypt_provider = new AesCryptoServiceProvider();
            crypt_provider.BlockSize = 128;
            crypt_provider.KeySize = 256;
            crypt_provider.GenerateIV();
            crypt_provider.GenerateKey();
            crypt_provider.Mode = CipherMode.CBC;
            crypt_provider.Padding = PaddingMode.PKCS7;

            ICryptoTransform transform = crypt_provider.CreateEncryptor();

            byte[] encrypted_bytes = transform.TransformFinalBlock(Encoding.Unicode.GetBytes(text), 0, text.Length);

            string str = Convert.ToBase64String(encrypted_bytes);

            return str;
        }
    }
}