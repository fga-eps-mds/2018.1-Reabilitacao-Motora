using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using fisioterapeuta;


/**
 * Cria um novo Fisioterapeuta no banco de dados.
 */
public class Login : MonoBehaviour 
{
	string path;
	Fisioterapeuta tableFisioterapeuta;

	public InputField login;
	public InputField pass;
	string wrongConfirmation = "FF7E7EFF";
     
	public static Color hexToColor(string hex)
	{
		byte a = 255;
		byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);

		if(hex.Length == 8){
			a = byte.Parse(hex.Substring(6,2), System.Globalization.NumberStyles.HexNumber);
		}
		return new Color32(r,g,b,a);
	}


	/**
 	 * Salva o Fisioterapeuta no banco.
 	 */
	public void Flow()
	{
		if (CheckLoginPass()) {
			SceneManager.LoadScene("Menu");
		} else {
			print("A combinação login+senha está incorreta!");
			ColorBlock cb = pass.colors;
			cb.normalColor = hexToColor(wrongConfirmation);
			login.colors = cb;
			pass.colors = cb;
		}
	}

	bool CheckLoginPass () 
	{
		path = "URI=file:" + Application.dataPath + "/Plugins/fisiotech.db";
		tableFisioterapeuta = new Fisioterapeuta(path);
		List<Fisioterapeuta.Fisioterapeutas> p = tableFisioterapeuta.Read();

		foreach (var fisio in p) 
		{			
			if (fisio.login == login.text && fisio.senha == pass.text) return true;
		}
		return false;
	}
}
