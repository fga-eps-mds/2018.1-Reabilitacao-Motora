using System;
using System.Text;
using System.Security.Cryptography;

namespace sha_256
{
	/**
	 * Hasheia a senha inserida, de forma que é quase impossível que duas senhas colidam (gerem a mesma Hash).
	 * Embora seja um ótimo algoritmo para encriptar, não é tão seguro justamente por ser otimizado como é;
	 * já que este consegue hashear grandes volumes de dados em pouco tempo, salvar uma senha simplesmente
	 * hasheada se torna inseguro, na medida em que, então, se torna facilmente suscetível à ataques de
	 * Brute-Force/Rainbow Table.
	 */
	public static class SHA_256 
	{
		public static string GenerateSHA256String(string password)
		{
			SHA256 sha256 = SHA256Managed.Create();
			byte[] bytes = Encoding.UTF8.GetBytes(password);
			byte[] hash = sha256.ComputeHash(bytes);

			return GetStringFromHash(hash);
		}

		private static string GetStringFromHash(byte[] hash)
		{
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < hash.Length; i++)
			{
				result.Append(hash[i].ToString("X2"));
			}

			return result.ToString();
		}
	}
}

