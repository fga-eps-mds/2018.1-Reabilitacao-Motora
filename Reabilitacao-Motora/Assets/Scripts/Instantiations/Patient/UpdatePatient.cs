using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using pessoa;
using paciente;

/**
 * Cria um novo paciente no banco de dados.
 */
public class UpdatePatient : MonoBehaviour 
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

	public void updatePatient()
	{


			var dateFormate = "";
			var trip = date.text.Split('/');

			if (date.text.Length > 1)
			{
				int x = 0;
				int.TryParse(trip[2], out x);

				if (x > 31) 
				{
					dateFormate = trip[2] + "/" + trip[1] + "/" + trip[0];
				}
				else 
				{
					dateFormate = trip[0] + "/" + trip[1] + "/" + trip[2];
				}
			}

			string newName; 
			string newDate; 
			string newP1; 
			string newP2; 
			string newNote; 
					
			if (namePatient.text.Length > 0) 
			{
				newName = (namePatient.text);
			}
			else
			{
				newName = (GlobalController.instance.user.persona.nomePessoa);
			}

			if (dateFormate.Length > 0) 
			{
				newDate = (dateFormate);
			}
			else
			{
				newDate = (GlobalController.instance.user.persona.dataNascimento);
			}

			if (phone1.text.Length > 0) 
			{
				newP1 = (phone1.text);
			}
			else
			{
				newP1 = (GlobalController.instance.user.persona.telefone1);
			}

			if (phone2.text.Length > 0) 
			{
				newP2 = (phone2.text);
			}
			else
			{
				newP2 = (GlobalController.instance.user.persona.telefone2);
			}

			if (notes.text.Length > 0) 
			{
				newNote = (notes.text);
			}
			else
			{
				newNote = (GlobalController.instance.user.observacoes);
			}

			if (male.isOn)
			{
				Pessoa.Update(GlobalController.instance.user.persona.idPessoa, newName, "m", newDate, newP1, newP2);
			}
			else if (female.isOn)
			{
				Pessoa.Update(GlobalController.instance.user.persona.idPessoa, newName, "f", newDate, newP1, newP2);
			}
						
			Paciente.Update(GlobalController.instance.user.idPaciente, GlobalController.instance.user.persona.idPessoa, newNote);

			Paciente tempPatient = Paciente.ReadValue(GlobalController.instance.user.idPaciente);
			GlobalController.instance.user = tempPatient;

			Flow.StaticPatient();
	}
}
