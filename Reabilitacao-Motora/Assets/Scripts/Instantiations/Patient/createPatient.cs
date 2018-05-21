using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

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
				ApplyColor (x, true);
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
			string pathNamePatient = "Assets\\Exercicios\\" + string.Format("{0}-{1}", personsList[personsList.Count-1].idPessoa, namePatientUnderscored);
			Directory.CreateDirectory(pathNamePatient);

			Flow.StaticNewPatient();
		}
	}

	private static bool ValidInput (List<InputField> inputs, List<Toggle> toggles)
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
			if (treatPhone2 != "")
			{
				var splitBar = treatPhone2.Split('|');
				foreach (var erro in splitBar)
				{
					print (erro);
				}

				ApplyColor (inputs[3], false);
			}
			
			valid = false;
		}

		return valid;
	}

	private static void ApplyColor (InputField input, bool ok)
	{
		input.colors = ColorManager.SetColor(input.colors, ok);
	}

}
