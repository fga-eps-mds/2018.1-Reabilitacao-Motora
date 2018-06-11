using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using pessoa;
using fisioterapeuta;


public class loadPhyisiotherapist : MonoBehaviour 
{
	[SerializeField]
	protected Text namePhysiotherapist, date, phone1, phone2, region, crefito;

	[SerializeField]
	protected Toggle male, female;

	public void Start()
	{
		if(GlobalController.instance.admin != null)
		{				
			if(GlobalController.instance.admin.persona.sexo == "m") 
			{
				male.isOn = true;
			}
			else
			{
				female.isOn = true;
			}
			
			namePhysiotherapist.text = GlobalController.instance.admin.persona.nomePessoa;
			date.text = GlobalController.instance.admin.persona.dataNascimento;
			phone1.text = GlobalController.instance.admin.persona.telefone1;
			phone2.text = GlobalController.instance.admin.persona.telefone2;
			region.text = GlobalController.instance.admin.regiao;
			crefito.text = GlobalController.instance.admin.crefito;
		}
		else
		{
			Debug.Log("Você violou o acesso!");	
		}

	}
}
