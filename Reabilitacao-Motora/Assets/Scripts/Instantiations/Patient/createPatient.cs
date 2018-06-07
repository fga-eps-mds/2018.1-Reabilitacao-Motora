using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
using System.Linq;

using pessoa;
using paciente;

/**
 * Cria um novo paciente no banco de dados.
 */
public class createPatient : MonoBehaviour
{
	[SerializeField]
	protected InputField namePatient, date, phone1, phone2, notes;

	[SerializeField]
	protected Toggle male, female;

	[SerializeField]
	protected Text helpPopUp;

	/**
	 * Salva o paciente no banco.
	 */
	public void savePatient()
	{
		List<InputField> allInputs = new List<InputField>();

		allInputs.Add(namePatient);
		allInputs.Add(date);
		allInputs.Add(phone1);
		allInputs.Add(phone2);
		allInputs.Add(notes);

		List<Toggle> allToggles = new List<Toggle>();
		allToggles.Add(male);
		allToggles.Add(female);

		if (ValidInput (allInputs, allToggles))
		{
			foreach (var x in allInputs)
			{
				ApplyColor (x, 1);
			}

			var trip = date.text.Split('/');
			var dateFormate = trip[2] + "/" + trip[1] + "/" + trip[0];
			string _phone2, _notes;

			if (male.isOn)
			{
				Pessoa.Insert(namePatient.text, "m", dateFormate, phone1.text, phone2.text);
			}
			else if(female.isOn)
			{
				Pessoa.Insert(namePatient.text, "f", dateFormate, phone1.text, phone2.text);
			}
			if (phone2 == null || phone2.text == "")
			{
				_phone2 = null;
			}
			else
			{
				_phone2 = phone2.text;
			}

			if (notes == null || notes.text == "")
			{
				_notes = null;
			}
			else
			{
				_notes = notes.text;
			}

			List<Pessoa> personsList = Pessoa.Read();
			Paciente.Insert(personsList[personsList.Count - 1].idPessoa, notes.text);

			string namePatientUnderscored = (namePatient.text).Replace(' ', '_');
			string pathNamePatient = Application.dataPath + string.Format("Exercicios/{0}-{1}", personsList[personsList.Count-1].idPessoa, namePatientUnderscored);
			Directory.CreateDirectory(pathNamePatient);

			var patients = Paciente.Read();

			GlobalController.instance.user = patients[patients.Count - 1];
			Flow.StaticNewPatient();
		}
	}

	public bool ValidInput (List<InputField> inputs, List<Toggle> toggles)
	{
		bool valid = true;

		string treatName = TreatFields.NameField (inputs[0].text);
		string treatDate = TreatFields.DateField (inputs[1].text);
		string treatPhone1 = TreatFields.PhoneField (inputs[2].text);
		string treatSex = TreatFields.SexField (toggles[0].isOn, toggles[1].isOn);

		string treatPhone2 = "";
		if (inputs[3].text != "")
		{
			treatPhone2 = TreatFields.PhoneField(inputs[3].text);
		}

		if (treatName != "" || treatDate != "" || treatPhone1 != "" ||
			treatPhone2 != "" || treatSex != "")
		{
			bool flag = true;
			StringBuilder fullerror = new StringBuilder();

			if (treatName != "" && flag)
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

			if (treatDate != "" && flag)
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

			if (treatPhone1 != "" && flag)
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

			if (treatPhone2 != "" && flag)
			{
				var splitBar = treatPhone2.Split('|');
				fullerror.Append("[Telefone2]: ");
				foreach (var erro in splitBar)
				{
					fullerror.Append(erro+'\n');
				}

				flag = false;
				ApplyColor (inputs[3], 0);
			}
			else if (treatPhone2 == "")
			{
				ApplyColor (inputs[3], 2);	
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

}
