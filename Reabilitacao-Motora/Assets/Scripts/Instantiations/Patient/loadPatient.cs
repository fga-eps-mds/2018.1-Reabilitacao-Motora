using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using pessoa;
using paciente;

/**
 * Cria um novo paciente no banco de dados.
 */
public class loadPatient : MonoBehaviour 
{
	[SerializeField]
	protected Text namePatient, date, phone1, phone2, notes;

	[SerializeField]
	protected Toggle male, female;

	public void Start()
	{
		if(GlobalController.instance != null &&
		   GlobalController.instance.user != null)
		{				
			if(GlobalController.instance.user.persona.sexo == "m" || GlobalController.instance.user.persona.sexo == "M") 
			{
				male.isOn = true;
			}
			else
			{
				female.isOn = true;
			}
			
			namePatient.text = GlobalController.instance.user.persona.nomePessoa;
			date.text = GlobalController.instance.user.persona.dataNascimento;
			phone1.text = GlobalController.instance.user.persona.telefone1;
			phone2.text = GlobalController.instance.user.persona.telefone2;
			notes.text = GlobalController.instance.user.observacoes;
		}
		else
		{
			Debug.Log("Você violou o acesso!");	
		}

	}
}
