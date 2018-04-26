using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using paciente;
using UnityEngine.SceneManagement;


public class setpatient : MonoBehaviour {

	public Paciente x;

	public void setepatient ()
	{
		GlobalController.instance.user = x;
		SceneManager.LoadScene("Patient");
	}
}
