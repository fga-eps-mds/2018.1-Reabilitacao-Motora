using System;
using System.Text;

public static class ByteToString
{
	public static string GetStringFromHash(byte[] hash)
	{
		StringBuilder result = new StringBuilder();
		for (int i = 0; i < hash.Length; i++)
		{
			result.Append(hash[i].ToString("X2"));
		}
		return result.ToString();
	}
}