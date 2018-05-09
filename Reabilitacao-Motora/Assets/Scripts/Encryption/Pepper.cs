using System;
using sha_512;

namespace pepper 
{
	/**
	 * Classe responsavel pela manipulação de Peppers.
	 */
	public static class Pepper 
	{
		/**
		 * Gera uma pepper aleatória, sendo composta por dois caracteres; podendo, cada um deles, ser um numero de 0 a 9 ou uma letra de A-z.
		 * Exemplos de possíveis peppers: 00, x4, Aa, 8z (etc)
		 * 
		 * Como há 62 possibilidades em cada caracter [(0-9 = 10 possibilidades) + (a-z = 26 possibilidades) + (A-Z = 26 possibilidades) = 62], é possível gerar
		 * 3844 peppers (62*62)
		 *
		 * Para simplicidade do código, decidimos tratar as possibilidades como se estivessem contidas num array (virtual), onde:
		 * - os primeiros 10 elementos são reservados aos numeros (0-9)
		 * - os elementos contidos entre a 10ª posição e 35ª posição são reservados às letras maiusculas (A-Z)
		 * - o restante dos elementos são reservados às letras minúsculas (a-z)
		 */
		public static string Generate ()
		{
			System.Random randomGenerator = new System.Random();

			int firstArrayIndex = randomGenerator.Next(0, 61);
			int secondArrayIndex = randomGenerator.Next(0, 61);

			string firstDigit = ConvertIndex(firstArrayIndex);
			string secondDigit = ConvertIndex(secondArrayIndex);

			string pepper = firstDigit + secondDigit;

			return pepper;
		}

		/**
		 * Como é impossível determinar pela senha salva no banco de dados qual Pepper foi gerada na criação da senha,
		 * esta função gera todas as combinações possiveis (00...AZ...zz); e, então, testa se com alguma delas, o resultado
		 * é igual ao que está salvo no banco de dados. Caso algum dos resultados seja igual ao que está salvo, retorna verdadeiro.
		 * Caso nenhuma delas resulte, a função retorna falso.
		 */
		public static bool Check (string password, string hashed, string salt)
		{
			for (int i = 0; i < 62; ++i)
			{
				for (int j = 0; j < 62; ++j) 
				{
					int firstArrayIndex = i;
					int secondArrayIndex = j;
					string firstDigit = ConvertIndex(firstArrayIndex);
					string secondDigit = ConvertIndex(secondArrayIndex);

					string pepper = firstDigit + secondDigit; 
					string aux = password + pepper;
					string result = salt + SHA_512.GenerateSHA512String(aux);

					if (result == hashed) 
					{
						return true;
					} 
				}
			}

			return false;
		}

		/**
		 * A conversão do numero aleatório gerado (de 0 à 61) se dá de forma que o numero resulte em seu respectivo caracter na tabela ASCII.
		 * Exemplos:
		 * 5: 5 + '0' = 5 + 48 = +53+
		 * b:
		 *   index(b) = 37
		 *   37 + 61 = +98+
		 * R:
		 *   index(R) = 27
		 *   27 + 55 = +82+
		 */
		private static string ConvertIndex (int index) 
		
		{
			int asciiDecimal;
			char digit;
			const int INTEGER_BOUND = 9;
			const int UPPER_CASE_BOUND = 35;
			const int TRANSFORM_TO_LOWER_CASE = 61;
			const int TRANSFORM_TO_UPPER_CASE = 55;
			const int TRANSFORM_TO_NUM = 48;

			if (index > INTEGER_BOUND) 
			{
				if (index > UPPER_CASE_BOUND) 
				{
					asciiDecimal = index + TRANSFORM_TO_LOWER_CASE;
				} 
				else 
				{
					asciiDecimal = index + TRANSFORM_TO_UPPER_CASE;
				}
			}
			else
			{
				asciiDecimal = index + TRANSFORM_TO_NUM;
			}

			digit = (char) asciiDecimal;

			return digit.ToString();
		}
	}
}
