using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using paciente;
using UnityEngine.SceneManagement;


public class SetPatientToButton : MonoBehaviour {

	private Paciente patient;

	public void SelectPatient ()
	{
		GlobalController.instance.user = patient;
	}

	public Paciente Patient
	{
		get 
		{ 
			return patient;
		}
		set 
		{ 
			patient = value; 
		}
	}
}
