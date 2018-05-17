using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pontosrotulopaciente;


public class SetLabel : MonoBehaviour 
{

	private PontosRotuloPaciente prp;

	public void SelectLabel ()
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
