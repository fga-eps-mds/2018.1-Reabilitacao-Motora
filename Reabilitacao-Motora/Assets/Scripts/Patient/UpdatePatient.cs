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
public class UpdatePatient : MonoBehaviour 
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

	public void updatePatient()
	{

			path = "URI=file:" + Application.dataPath + "/Plugins/fisiotech.db";

			var dateFormate = "";
			var trip = date.text.Split('/');
			if (date.text.Length > 1){
				int x = 0;
				int.TryParse(trip[2], out x);

				if (x > 31) dateFormate = trip[2] + "/" + trip[1] + "/" + trip[0];
				else dateFormate = trip[0] + "/" + trip[1] + "/" + trip[2];
			}
		
			tablePessoa = new Pessoa(path);
			tablePaciente = new Paciente(path);
			
			string newName = (namePatient.text.Length > 0) ? (namePatient.text) : (GlobalController.instance.user.persona.nomePessoa);
			string newDate = (dateFormate.Length > 0) ? (dateFormate) : (GlobalController.instance.user.persona.dataNascimento);
			string newP1 = (phone1.text.Length > 0) ? (phone1.text) : (GlobalController.instance.user.persona.telefone1);
			string newP2 = (phone2.text.Length > 0) ? (phone2.text) : (GlobalController.instance.user.persona.telefone2);
			string newNote = (notes.text.Length > 0) ? (notes.text) : (GlobalController.instance.user.observacoes);


			if (male.isOn) 
				tablePessoa.Update(GlobalController.instance.user.persona.idPessoa, newName, "m", newDate, newP1, newP2);
			else if(female.isOn)
				tablePessoa.Update(GlobalController.instance.user.persona.idPessoa, newName, "f", newDate, newP1, newP2);
			
			List<Pessoa.Pessoas> p = tablePessoa.Read();
			
			tablePaciente.Update(GlobalController.instance.user.idPaciente, GlobalController.instance.user.persona.idPessoa, newNote);
	}
}