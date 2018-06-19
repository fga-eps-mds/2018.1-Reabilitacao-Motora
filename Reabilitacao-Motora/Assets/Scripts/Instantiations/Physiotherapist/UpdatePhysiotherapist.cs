using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using pessoa;
using fisioterapeuta;

/**
 * Cria um novo Fisioterapeuta no banco de dados.
 */
public class UpdatePhysiotherapist : MonoBehaviour 
{
	[SerializeField]
	protected InputField namePhysiotherapist, date, phone1, phone2, region, crefito;
	
	[SerializeField]
	protected Toggle male, female;

	/**
	 * Salva o Fisioterapeuta no banco.
	 */

	public void updatePhysiotherapist()
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
		string newRegion; 
		string newCrefito; 
				
		if (namePhysiotherapist.text.Length > 0) 
		{
			newName = (namePhysiotherapist.text);
		}
		else
		{
			newName = (GlobalController.instance.admin.persona.nomePessoa);
		}

		if (dateFormate.Length > 0) 
		{
			newDate = (dateFormate);
		}
		else
		{
			newDate = (GlobalController.instance.admin.persona.dataNascimento);
		}

		if (phone1.text.Length > 0) 
		{
			newP1 = (phone1.text);
		}
		else
		{
			newP1 = (GlobalController.instance.admin.persona.telefone1);
		}

		if (phone2.text.Length > 0) 
		{
			newP2 = (phone2.text);
		}
		else
		{
			newP2 = (GlobalController.instance.admin.persona.telefone2);
		}

		if (region.text.Length > 0) 
		{
			newRegion = (region.text);
		}
		else
		{
			newRegion = (GlobalController.instance.admin.regiao);
		}

		if (crefito.text.Length > 0) 
		{
			newCrefito = (crefito.text);
		}
		else
		{
			newCrefito = (GlobalController.instance.admin.crefito);
		}

		if (male.isOn)
		{
			Pessoa.Update(GlobalController.instance.admin.persona.idPessoa, newName, "m", newDate, newP1, newP2);
		}
		else if (female.isOn)
		{
			Pessoa.Update(GlobalController.instance.admin.persona.idPessoa, newName, "f", newDate, newP1, newP2);
		}
					
		Fisioterapeuta.Update(GlobalController.instance.admin.idFisioterapeuta, GlobalController.instance.admin.persona.idPessoa, GlobalController.instance.admin.login, GlobalController.instance.admin.senha, newRegion, newCrefito);

		Fisioterapeuta tempPhysiotherapist = Fisioterapeuta.ReadValue(GlobalController.instance.admin.idFisioterapeuta);
		GlobalController.instance.admin = tempPhysiotherapist;

		Flow.StaticPhysiotherapist();
	}
}
