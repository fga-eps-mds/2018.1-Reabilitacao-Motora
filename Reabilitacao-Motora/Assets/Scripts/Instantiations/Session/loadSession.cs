using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using pessoa;
using paciente;

/**
 * Cria um novo paciente no banco de dados.
 */
public class loadSession : MonoBehaviour 
{
	public InputField Date;
	private InputField date
	{
		get
		{
			return Date;
		}
		set
		{
			Date = value;
		}
	}

	public InputField Notes;
	private InputField notes
	{
		get
		{
			return Notes;
		}
		set
		{
			Notes = value;
		}
	}
	
	void Start()
	{
		if(GlobalController.instance != null &&
		   GlobalController.instance.session != null)
		{							
			date.text = GlobalController.instance.session.dataSessao;
			notes.text = GlobalController.instance.session.observacaoSessao;
		}
		else
		{
			Debug.Log("Você violou o acesso!");	
		}

	}
}
