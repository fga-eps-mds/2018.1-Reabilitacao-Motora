using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fisioterapeuta;
using UnityEngine.SceneManagement;


public class SetPhysiotherapistToButton : MonoBehaviour {

	private Fisioterapeuta physiotherapist;

	public void SelectPhysiotherapist ()
	{
		GlobalController.instance.admin = physiotherapist;
	}

	public Fisioterapeuta Physiotherapist
	{
		get 
		{ 
			return physiotherapist;
		}
		set 
		{ 
			physiotherapist = value; 
		}
	}
}
