using bcrypt;
using aes256;
using sha_256;
using sha_512;
using pepper;
using UnityEngine;

namespace cryptpw 
{
	/**
	 * Lida com a encriptação da senha recebida e com a "desencriptação" do que está salvo no banco de dados.
	 */
	public static class CryptPassword
	{
		/**
		 * O procedimento é:
		 * - recebe senha X
		 * - Hasheia X com SHA256, resultando em Y
		 * - "Acopla" o nounce (login) no final d'este resultado (Y), resultando em Z
		 * - gera um Salt aleatório, com 29 caracteres
		 * - Utiliza o BCrypt para gerar outra hash, sendo esta resultado do Salt + Z, resultando em W
		 * - Como os primeiros 29 caracteres de W são o proprio salt, encripta-se, com o AES, apenas os caracteres que não fazem parte do Salt, resultando Salt + R
		 * - aclopa-se, então, uma Pepper aleatória ao final da string, sendo esta, agora, composta por Salt + R + Pepper; resultando em G
		 * - Por fim, hasheia-se G com SHA512 e adiciona ao início da string o Salt; resultando em Salt+F
		 */
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

		/**
		 * Repete o mesmo procedimento de encriptação e compara as hashs resultadas com
		 * o que está salvo no banco de dados.
		 */
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