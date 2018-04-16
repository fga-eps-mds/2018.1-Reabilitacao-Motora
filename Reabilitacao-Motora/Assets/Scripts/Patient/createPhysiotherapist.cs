using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

using pessoa;
using fisioterapeuta;
using telefone;

/**
 * Cria um novo Fisioterapeuta no banco de dados.
 */
public class createPhysiotherapist : MonoBehaviour 
{
	string path, pathnamephysio;
	Pessoa tablePessoa;
	Fisioterapeuta tableFisioterapeuta;
	Telefone tableTelefone;

	public InputField name;
	public InputField date;
	public InputField phone;
	public InputField crefito;
	public InputField regiao;
	public InputField login;
	public InputField pass;
	public InputField confirmPass;
	string wrongConfirmation = "FF7E7EFF", success = "87E580FF";
     
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
	public void savePhysiotherapist()
	{
		if (pass.text == confirmPass.text) {
			ColorBlock cb = confirmPass.colors;
			cb.normalColor = hexToColor(success);
			confirmPass.colors = cb;
			pass.colors = cb;

			path = "URI=file:" + Application.dataPath + "/Plugins/fisiotech.db";

			var trip = date.text.Split('/');
			var dateFormate = trip[2] + "/" + trip[1] + "/" + trip[0];
			
			tablePessoa = new Pessoa(path);
			tableFisioterapeuta = new Fisioterapeuta(path);
			tablePessoa.Insert(name.text, "f", dateFormate);

			List<Pessoa.Pessoas> p = tablePessoa.Read();
			
			tableFisioterapeuta.Insert(p[p.Count -1].idPessoa, login.text, pass.text, crefito.text, regiao.text);

			pathnamephysio = "URI=file:" + Application.dataPath + "/Movimentos/" + string.Format("\"{0}\"", name.text);
			Directory.CreateDirectory(pathnamephysio);

			SceneManager.LoadScene("Login");
		} else {
			print("As senhas não condizem!");
			ColorBlock cb = confirmPass.colors;
			cb.normalColor = hexToColor(wrongConfirmation);
			pass.colors = cb;
			confirmPass.colors = cb;
		}
	}
}
