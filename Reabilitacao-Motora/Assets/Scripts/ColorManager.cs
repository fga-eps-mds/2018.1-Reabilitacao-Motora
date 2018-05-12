using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ColorManager
{
	private const string WrongConfirmation = "FF7E7EFF", Success = "87E580FF";
	
	public static Color wrongConfirmation
	{
		get 
		{
			return hexToColor (WrongConfirmation);
		}
	}

	public static Color success
	{
		get 
		{
			return hexToColor (Success);
		}
	}

	private static Color hexToColor(string hex)
	{
		byte a = 255;
		byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);

		if(hex.Length == 8)
		{
			a = byte.Parse(hex.Substring(6,2), System.Globalization.NumberStyles.HexNumber);
		}
		return new Color32(r,g,b,a);
	}
}
