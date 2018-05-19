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
		if(namePatient.text != "" && date.text != "" && phone1.text != "") 
		{
			var trip = date.text.Split('/');
			var dateFormate = trip[2] + "/" + trip[1] + "/" + trip[0];
		
			if (male.isOn)
			{
				Pessoa.Insert(namePatient.text, "m", dateFormate, phone1.text, phone2.text);
			}
			else if(female.isOn)
			{
				Pessoa.Insert(namePatient.text, "f", dateFormate, phone1.text, phone2.text);
			}

			List<Pessoa> personsList = Pessoa.Read();
			Paciente.Insert(personsList[personsList.Count - 1].idPessoa, notes.text);

			string namePatientUnderscored = (namePatient.text).Replace(' ', '_');
			string pathNamePatient = "Assets\\Exercicios\\" + string.Format("{0}-{1}", personsList[personsList.Count-1].idPessoa, namePatientUnderscored);
			Directory.CreateDirectory(pathNamePatient);

			Flow.StaticNewPatient();
		}
	}
}
