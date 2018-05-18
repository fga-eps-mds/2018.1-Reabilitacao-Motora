using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pontosrotulopaciente;


public class SetLabelPatient : MonoBehaviour 
{

	private PontosRotuloPaciente prp;

	public void SelectLabelPatient ()
	{
		GlobalController.instance.prp = prp;
	}

	public PontosRotuloPaciente Prp
	{
		get 
		
		{
			return prp;
		}
		set 
		{
			prp = value; 
		}
	}
}
