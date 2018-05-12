using System;
using System.Text;
using System.Security.Cryptography;

namespace aes256
{
	/**
	* Utiliza-se da classe AES que o próprio C# dispõe em sua biblioteca System.Security.Cryptography.
	* Utiliza uma Key estática para encriptação de texto, assim como, também, um array inicial estático (IV).
	*/
	public static class AES256 
	{
		private static readonly byte[] xd = {
			102, 41, 131, 214, 31, 
			43, 204, 70, 98, 6, 
			136, 250, 83, 214, 52, 
			173, 153, 193, 196, 248, 
			199, 170, 68, 96, 179, 
			86, 115, 138, 17, 62, 
			223, 64
		};

		private static readonly byte[] dx = {
			40, 182, 128, 213, 207, 
			87, 88, 165, 28, 158, 
			169, 172, 180, 6, 175, 
			39
		};

		public static string AES_Encrypt (string text) 
		{

			AesCryptoServiceProvider crypt_provider = new AesCryptoServiceProvider();
			crypt_provider.BlockSize = 128;
			crypt_provider.KeySize = 256;
			crypt_provider.IV = dx;
			crypt_provider.Key = xd;
			crypt_provider.Mode = CipherMode.CBC;
			crypt_provider.Padding = PaddingMode.PKCS7;

			ICryptoTransform transform = crypt_provider.CreateEncryptor();
			byte[] encrypted_bytes = transform.TransformFinalBlock(Encoding.Unicode.GetBytes(text), 0, text.Length);

			string str = Convert.ToBase64String(encrypted_bytes);
			return str;
		}
	}
}
