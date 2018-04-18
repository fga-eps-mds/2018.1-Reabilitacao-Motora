using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using pessoa;
using paciente;
using telefone;

/**
 * Cria um novo paciente no banco de dados.
 */
public class createPatient : MonoBehaviour 
{
	string path;
	Pessoa tablePessoa;
	Paciente tablePaciente;

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
		if(namePatient.text == "" || date.text == "" || phone1.text == "") {
			
		} else {
			path = "URI=file:" + Application.dataPath + "/Plugins/fisiotech.db";

			var trip = date.text.Split('/');
			var dateFormate = trip[2] + "/" + trip[1] + "/" + trip[0];
		
			tablePessoa = new Pessoa(path);
			tablePaciente = new Paciente(path);
			if (male.isOn)
				tablePessoa.Insert(namePatient.text, "m", dateFormate, phone1.text, phone2.text);
			else if(female.isOn)
				tablePessoa.Insert(namePatient.text, "f", dateFormate, phone1.text, phone2.text);

			List<Pessoa.Pessoas> p = tablePessoa.Read();
			
			tablePaciente.Insert(p[p.Count -1].idPessoa, notes.text);
		}
	}
}
