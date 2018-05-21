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
		List<InputField> allInputs = new List<InputField>();
			
		allInputs.Add(namePhysio); 
		allInputs.Add(date); 
		allInputs.Add(phone1); 
		allInputs.Add(login); 
		allInputs.Add(pass); 
		allInputs.Add(confirmPass);
		allInputs.Add(crefito); 
		allInputs.Add(regiao); 
		allInputs.Add(phone2);

		List<Toggle> allToggles = new List<Toggle>();
		allToggles.Add(male);
		allToggles.Add(female);
		

		if (ValidInput (allInputs, allToggles) && ((crefito == null) == (regiao == null)))
		{
			foreach (var x in allInputs)
			{
				ApplyColor (x, true);
			}

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
	}

	private static bool ValidInput (List<InputField> inputs, List<Toggle> toggles)
	{
		bool valid = true;

		string treatName = TreatFields.NameField (inputs[0].text);
		string treatDate = TreatFields.DateField (inputs[1].text);
		string treatPhone1 = TreatFields.PhoneField (inputs[2].text);
		string treatLogin = TreatFields.LoginField (inputs[3].text);
		string treatPass = TreatFields.PasswordField (inputs[4].text);
		string treatConfirm = TreatFields.ConfirmPasswordField (inputs[5].text, inputs[4].text);
		string treatSex = TreatFields.SexField (toggles[0].isOn, toggles[1].isOn);

		string treatCrefito = "";
		string treatRegiao = "";
		string treatUniqueCR = "";

		if (inputs[6].text != "" && inputs[7].text != "")
		{
			treatCrefito = TreatFields.CrefitoField (inputs[6].text);
			treatRegiao = TreatFields.RegionField (inputs[7].text);
			treatUniqueCR = TreatFields.UniqueCrefitoRegion (inputs[6].text, inputs[7].text);
		}

		string treatPhone2 = "";
		if (inputs[8].text != "")
		{
			treatPhone2 = TreatFields.PhoneField(inputs[8].text);
		}

		string treatUniqueLP = TreatFields.UniqueLoginPassword(inputs[3].text);

		if (treatName != "" || treatDate != "" || treatPhone1 != "" ||
			treatCrefito != "" || treatRegiao != "" || treatLogin != "" ||
			treatPass != "" || treatConfirm != "" || treatPhone2 != "" ||
			treatSex != "" || treatUniqueCR != "" || treatUniqueLP != "")
		{
			if (treatName != "")
			{
				var splitBar = treatName.Split('|');
				foreach (var erro in splitBar)
				{
					print (erro);
				}

				ApplyColor (inputs[0], false);
			} 
			if (treatDate != "")
			{
				var splitBar = treatDate.Split('|');
				foreach (var erro in splitBar)
				{
					print (erro);
				}

				ApplyColor (inputs[1], false);
			} 
			if (treatPhone1 != "")
			{
				var splitBar = treatPhone1.Split('|');
				foreach (var erro in splitBar)
				{
					print (erro);
				}

				ApplyColor (inputs[2], false);
			} 
			if (treatLogin != "")
			{
				var splitBar = treatLogin.Split('|');
				foreach (var erro in splitBar)
				{
					print (erro);
				}

				ApplyColor (inputs[3], false);
			}
			if (treatPass != "")
			{
				var splitBar = treatPass.Split('|');
				foreach (var erro in splitBar)
				{
					print (erro);
				}

				ApplyColor (inputs[4], false);
			} 
			if (treatConfirm != "")
			{
				var splitBar = treatConfirm.Split('|');
				foreach (var erro in splitBar)
				{
					print (erro);
				}

				ApplyColor (inputs[5], false);
			} 
			if (treatCrefito != "")
			{
				var splitBar = treatCrefito.Split('|');
				foreach (var erro in splitBar)
				{
					print (erro);
				}

				ApplyColor (inputs[6], false);
			} 
			if (treatRegiao != "")
			{
				var splitBar = treatRegiao.Split('|');
				foreach (var erro in splitBar)
				{
					print (erro);
				}

				ApplyColor (inputs[7], false);
			} 
			if (treatPhone2 != "")
			{
				var splitBar = treatPhone2.Split('|');
				foreach (var erro in splitBar)
				{
					print (erro);
				}

				ApplyColor (inputs[8], false);
			}
			if (treatUniqueCR != "")
			{
				var splitBar = treatUniqueCR.Split('|');
				foreach (var erro in splitBar)
				{
					print (erro);
				}

				ApplyColor (inputs[6], false);
				ApplyColor (inputs[7], false);
			}
			if (treatUniqueLP != "")
			{
				var splitBar = treatUniqueLP.Split('|');
				foreach (var erro in splitBar)
				{
					print (erro);
				}

				ApplyColor (inputs[3], false);
				ApplyColor (inputs[4], false);
			} 

			valid = false;
		}

		return valid;
	}

	private static void ApplyColor (InputField input, bool ok)
	{
		input.colors = ColorManager.SetColor(input.colors, ok);
	}

	private static void CreateDirectoryPhysio (string name, int idPessoa)
	{
		string namePhysioUnderscored = name.Replace(' ', '_');
		string pathnamephysio = "Assets\\Movimentos\\" + string.Format("{0}-{1}", idPessoa, namePhysioUnderscored);
		Directory.CreateDirectory(pathnamephysio);
	}
}
