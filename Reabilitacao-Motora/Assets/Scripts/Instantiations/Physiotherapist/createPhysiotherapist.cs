using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
		System.Object[] inputs = new System.Object[] {namePhysio, date, phone1, login, pass, confirmPass, male, female};
		if (ValidInput (inputs) && ((crefito == null) == (regiao == null)))
		{
			if (pass.text == confirmPass.text) 
			{
				SetColor (true);

				string encryptedPassword = CryptPassword.Encrypt(pass.text, login.text);			

				var trip = date.text.Split('/');
				var dateFormate = trip[2] + "/" + trip[1] + "/" + trip[0];
				
				string sex, _phone2, _crefito, _regiao;
				
				if (male.isOn)
				{
					sex = "m";
				}
				else
				{
					sex = "f";
				}

				if (phone2 == null || phone2.text == "")
				{
					_phone2 = null;
				}
				else
				{
					_phone2 = phone2.text;
				}

				if (crefito == null || crefito.text == "")
				{
					_crefito = null;
					_regiao = null;
				}
				else
				{
					_crefito = crefito.text;
					_regiao = regiao.text;
				}


				Pessoa.Insert(namePhysio.text, sex, dateFormate, phone1.text, _phone2);
				List<Pessoa> p = Pessoa.Read();

				Fisioterapeuta.Insert(p[p.Count -1].idPessoa, login.text, encryptedPassword, _crefito, _regiao);

				CreateDirectoryPhysio (namePhysio.text, p[p.Count-1].idPessoa);

				List<Fisioterapeuta> physios = Fisioterapeuta.Read();
				GlobalController.instance.admin = physios[physios.Count - 1]; 

				Flow.StaticLogin();
			} 
			else 
			{
				print("As senhas não condizem!");
				SetColor (false);
			}
		}
	}

	private static bool ValidInput (System.Object[] inputs)
	{
		bool valid = true;
		const short FEMALE_INDEX = 7;
		for (int i = 0; i < inputs.Length; ++i)
		{
			if (inputs[i] == null)
			{
				valid = false;
			}
			else
			{
				Type t = inputs[i].GetType();
				if (t.Equals(typeof(InputField))) 
				{
					InputField aux = (InputField)inputs[i];
					if (aux.text == "")
					{
						valid = false;
						print("input field " + i);
					}
				}
				else
				{
					Toggle aux1 = (Toggle)inputs[i], aux2 = (Toggle)inputs[FEMALE_INDEX];
					if (aux1.isOn == aux2.isOn)
					{
						valid = false;
						print ("toggle" + i);
					}
					break;
				}
			}
		}

		return valid;
	}

	private static void CreateDirectoryPhysio (string name, int idPessoa)
	{
		string namePhysioUnderscored = name.Replace(' ', '_');
		string pathnamephysio = "Assets\\Movimentos\\" + string.Format("{0}-{1}", idPessoa, namePhysioUnderscored);
		Directory.CreateDirectory(pathnamephysio);
	}

	private void SetColor (bool ok)
	{
		ColorBlock cb = confirmPass.colors;  
		if (ok)
		{
			cb.normalColor = ColorManager.success;
		}
		else
		{
			cb.normalColor = ColorManager.wrongConfirmation;
		}
		confirmPass.colors = cb;
		pass.colors = cb;
	}
}
