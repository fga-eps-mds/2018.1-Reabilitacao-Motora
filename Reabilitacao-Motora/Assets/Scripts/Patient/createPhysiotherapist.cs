﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

using cryptpw;

using pessoa;
using fisioterapeuta;

/**
 * Cria um novo Fisioterapeuta no banco de dados.
 */
public class createPhysiotherapist : MonoBehaviour 
{	
	public InputField namePhysio;
	public InputField date;
	public InputField phone1, phone2;
	public InputField crefito;
	public InputField regiao;
	public InputField login;
	public InputField pass;
	public InputField confirmPass;
	public Toggle male;
	public Toggle female;
	private const string wrongConfirmation = "FF7E7EFF", success = "87E580FF";
	 
	public static Color hexToColor(string hex)
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


	/**
	 * Salva o Fisioterapeuta no banco.
	 */
	public void savePhysiotherapist()
	{
		if (pass.text == confirmPass.text) 
		{
			string encryptedPassword = CryptPassword.Encrypt(pass.text, login.text);
			ColorBlock cb = confirmPass.colors;
			cb.normalColor = hexToColor(success);
			confirmPass.colors = cb;
			pass.colors = cb;

			var trip = date.text.Split('/');
			var dateFormate = trip[2] + "/" + trip[1] + "/" + trip[0];
			
			string sex;
			
			if (male.isOn)
			{
				sex = "m";
			}
			else
			{
				sex = "f";
			}

			Pessoa.Insert(namePhysio.text, sex, dateFormate, phone1.text, phone2.text);

			List<Pessoa> p = Pessoa.Read();

			Fisioterapeuta.Insert(p[p.Count -1].idPessoa, login.text, encryptedPassword, crefito.text, regiao.text);

			string namePhysioUnderscored = (namePhysio.text).Replace(' ', '_');

			string pathnamephysio = "Assets\\Movimentos\\" + string.Format("{0}-{1}", p[p.Count-1].idPessoa, namePhysioUnderscored);

			Directory.CreateDirectory(pathnamephysio);

			Flow.StaticLogin();
		} 
		else 
		{
			print("As senhas não condizem!");
			ColorBlock cb = confirmPass.colors;
			cb.normalColor = hexToColor(wrongConfirmation);
			pass.colors = cb;
			confirmPass.colors = cb;
		}
	}
}
