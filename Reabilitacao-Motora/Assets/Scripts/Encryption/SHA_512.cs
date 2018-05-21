using System;
using System.Text;
using System.Security.Cryptography;

namespace sha_512
{
	/**
	 * Hasheia a senha inserida, de forma que é quase impossível que duas senhas colidam (gerem a mesma Hash).
	 * Embora seja um ótimo algoritmo para encriptar, não é tão seguro justamente por ser otimizado como é;
	 * já que este consegue hashear grandes volumes de dados em pouco tempo, salvar uma senha simplesmente
	 * hasheada se torna inseguro, na medida em que, então, se torna facilmente suscetível à ataques de
	 * Brute-Force/Rainbow Table.
	 */
	public static class SHA_512 
	{
		public static string GenerateSHA512String(string password)
		{
			SHA512 sha512 = SHA512Managed.Create();
			byte[] bytes = Encoding.UTF8.GetBytes(password);
			byte[] hash = sha512.ComputeHash(bytes);

			return ByteToString.GetStringFromHash(hash);
		}
	}
}

