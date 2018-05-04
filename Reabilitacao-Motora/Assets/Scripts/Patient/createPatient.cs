using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using pessoa;
using paciente;

/**
 * Cria um novo paciente no banco de dados.
 */
public class createPatient : MonoBehaviour 
{
	public InputField namePatient;
	public InputField date;
	public InputField phone1;
	public InputField phone2;
	public InputField notes;
	public Toggle male;
	public Toggle female;

	/**
 	 * Salva o paciente no banco.
 	 */
	public void savePatient()
	{
		if(namePatient.text != "" && date.text != "" && phone1.text != "") {
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
		}
	}
}
