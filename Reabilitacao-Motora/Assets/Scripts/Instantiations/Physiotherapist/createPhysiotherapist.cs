using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Linq;

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

	[SerializeField]
	protected Text helpPopUp;

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
				ApplyColor (x, 1);
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

			Fisioterapeuta.Insert(p[p.Count -1].idPessoa, login.text, encryptedPassword, _regiao, _crefito);

			CreateDirectoryPhysio (namePhysio.text, p[p.Count-1].idPessoa);

			List<Fisioterapeuta> physios = Fisioterapeuta.Read();
			GlobalController.instance.admin = physios[physios.Count - 1]; 

			Flow.StaticLogin();
		} 
	}

	public bool ValidInput (List<InputField> inputs, List<Toggle> toggles)
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
			bool flag = true;
			StringBuilder fullerror = new StringBuilder();

			if ((treatName != "") && flag)
			{
				var splitBar = treatName.Split('|');
				fullerror.Append("[Nome]: ");
				foreach (var erro in splitBar)
				{
					fullerror.Append(erro+'\n');
				}

				flag = false;
				ApplyColor (inputs[0], 0);
			}
			else if (treatName == "")
			{
				ApplyColor (inputs[0], 2);
			}

			if (treatSex != "" && flag)
			{
				var splitBar = treatSex.Split('|');
				fullerror.Append("[Sexo]: ");
				foreach (var erro in splitBar)
				{
					fullerror.Append(erro+'\n');
				}

				flag = false;
				ApplyColor (toggles[0], 0);
				ApplyColor (toggles[1], 0);
			}
			else if (treatSex == "")
			{
				ApplyColor (toggles[0], 2);
				ApplyColor (toggles[1], 2);
			}

			if ((treatDate != "") && flag)
			{
				var splitBar = treatDate.Split('|');
				fullerror.Append("[Data de Nascimento]: ");
				foreach (var erro in splitBar)
				{
					fullerror.Append(erro+'\n');
				}

				flag = false;
				ApplyColor (inputs[1], 0);
			}
			else if (treatDate == "")
			{
				ApplyColor (inputs[1], 2);
			} 

			if ((treatPhone1 != "") && flag)
			{
				var splitBar = treatPhone1.Split('|');
				fullerror.Append("[Telefone1]: ");
				foreach (var erro in splitBar)
				{
					fullerror.Append(erro+'\n');
				}

				flag = false;
				ApplyColor (inputs[2], 0);
			}
			else if (treatPhone1 == "")
			{
				ApplyColor (inputs[2], 2);
			} 

			if ((treatLogin != "" || treatUniqueLP != "") && flag)
			{
				var splitBar = treatLogin.Split('|');
				fullerror.Append("[Login]: ");
				if (treatLogin != "")
				{
					foreach (var erro in splitBar)
					{
						fullerror.Append(erro+'\n');
					}
				}

				splitBar = treatUniqueLP.Split('|');
				if (treatUniqueLP != "")
				{
					foreach (var erro in splitBar)
					{
						fullerror.Append(erro+'\n');
					}
				}

				flag = false;
				ApplyColor (inputs[3], 0);
			}
			else if (treatLogin == "" && treatUniqueLP == "")
			{
				ApplyColor (inputs[3], 2);
			}

			if ((treatPass != "") && flag)
			{
				var splitBar = treatPass.Split('|');
				fullerror.Append("[Senha]: ");
				foreach (var erro in splitBar)
				{
					fullerror.Append(erro+'\n');
				}

				flag = false;
				ApplyColor (inputs[4], 0);
			}
			else if (treatPass == "")
			{
				ApplyColor (inputs[4], 2);
			} 

			if ((treatConfirm != "") && flag)
			{
				var splitBar = treatConfirm.Split('|');
				fullerror.Append("[Confirmar Senha]: ");
				foreach (var erro in splitBar)
				{
					fullerror.Append(erro+'\n');
				}

				flag = false;
				ApplyColor (inputs[5], 0);
			}
			else if (treatConfirm == "")
			{
				ApplyColor (inputs[5], 2);
			} 

			if ((treatCrefito != "" || treatUniqueCR != "") && flag)
			{
				var splitBar = treatCrefito.Split('|');
				fullerror.Append("[CREFITO]: ");
				if (treatCrefito != "")
				{
					foreach (var erro in splitBar)
					{
						fullerror.Append(erro+'\n');
					}
				}

				splitBar = treatUniqueCR.Split('|');
				if (treatUniqueCR != "")
				{
					foreach (var erro in splitBar)
					{
						fullerror.Append(erro+'\n');
					}
				}

				flag = false;
				ApplyColor (inputs[6], 0);
			}
			else if (treatCrefito == "" && treatUniqueCR == "")
			{
				ApplyColor (inputs[6], 2);
			} 

			if ((treatRegiao != "" || treatUniqueCR != "") && flag)
			{
				var splitBar = treatRegiao.Split('|');
				fullerror.Append("[Regiao]: ");
				if (treatRegiao != "")
				{
					foreach (var erro in splitBar)
					{
						fullerror.Append(erro+'\n');
					}
				}

				splitBar = treatUniqueCR.Split('|');
				if (treatUniqueCR != "")
				{
					foreach (var erro in splitBar)
					{
						fullerror.Append(erro+'\n');
					}
				}

				flag = false;
				ApplyColor (inputs[7], 0);
			}
			else if (treatRegiao == "" && treatUniqueCR == "")
			{
				ApplyColor (inputs[7], 2);
			} 

			if ((treatPhone2 != "") && flag)
			{
				var splitBar = treatPhone2.Split('|');
				fullerror.Append("[Telefone2]: ");
				foreach (var erro in splitBar)
				{
					fullerror.Append(erro+'\n');
				}

				flag = false;
				ApplyColor (inputs[8], 0);
			}
			else if (treatPhone2 == "")
			{
				ApplyColor (inputs[8], 2);
			}

			helpPopUp.text = fullerror.ToString();
			int count = fullerror.ToString().Count(f => f == '\n');
			int top = -90 + (count * 30);
			float right = 300.0f - helpPopUp.preferredWidth;

			helpPopUp.transform.localPosition = new Vector3(helpPopUp.transform.localPosition.x, 0, helpPopUp.transform.localPosition.z);

			helpPopUp.transform.parent.gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(right, -top);
			helpPopUp.transform.parent.gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(-right, top);
			helpPopUp.transform.parent.gameObject.SetActive(true);

			valid = false;
		}

		return valid;
	}

	public static void ApplyColor (InputField input, int ok)
	{
		input.colors = ColorManager.SetColor(input.colors, ok);
	}

	public static void ApplyColor (Toggle toggle, int ok)
	{
		toggle.colors = ColorManager.SetColor(toggle.colors, ok);
	}


	private static void CreateDirectoryPhysio (string name, int idPessoa)
	{
		string namePhysioUnderscored = name.Replace(' ', '_');
		string pathnamephysio = Application.dataPath + string.Format("/Movimentos/{0}-{1}", idPessoa, namePhysioUnderscored);
		Directory.CreateDirectory(pathnamephysio);
	}
}
