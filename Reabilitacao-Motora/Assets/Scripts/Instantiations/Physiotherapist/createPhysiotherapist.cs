using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

using cryptpw;

using pessoa;
using fisioterapeuta;

/**
 * Cria um novo Fisioterapeuta no banco de dados.
 */
public class createPhysiotherapist : MonoBehaviour 
{
	[SerializeField]
	protected InputField namePhysio, date, phone1, phone2, crefito, regiao, login, pass, confirmPass;

	[SerializeField]
	protected Toggle male, female;

	/**
	 * Salva o Fisioterapeuta no banco.
	 */
	public void savePhysiotherapist()
	{
		if (pass.text == confirmPass.text) 
		{
			string encryptedPassword = CryptPassword.Encrypt(pass.text, login.text);
			ColorBlock cb = confirmPass.colors;
			cb.normalColor = ColorManager.success;
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

			List<Fisioterapeuta> physios = Fisioterapeuta.Read();
			GlobalController.instance.admin = physios[physios.Count - 1]; 

			Flow.StaticLogin();
		} 
		else 
		{
			print("As senhas não condizem!");
			ColorBlock cb = confirmPass.colors;
			cb.normalColor = ColorManager.wrongConfirmation;
			pass.colors = cb;
			confirmPass.colors = cb;
		}
	}
}
