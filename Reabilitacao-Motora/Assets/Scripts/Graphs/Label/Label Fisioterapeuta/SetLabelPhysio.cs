using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pontosrotulofisioterapeuta;


public class SetLabelPhysio : MonoBehaviour 
{

	private PontosRotuloFisioterapeuta prf;

	public void SelectLabelPhysio ()
	{
		GlobalController.instance.prf = prf;
	}

	public PontosRotuloFisioterapeuta Prf
	{
		get 
		
		{
			return prf;
		}
		set 
		{
			prf = value; 
		}
	}
}
