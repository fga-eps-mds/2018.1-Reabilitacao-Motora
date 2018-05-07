using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using paciente;

public class instanciatePatient : MonoBehaviour 
{

	public GameObject buttonPrefab;

	int heightOffset = 60;
	const int HEIGHT_PADDING = 55;

	void ButtonSpawner(int posY, Paciente patient)
	{
		GameObject go = Instantiate(buttonPrefab, transform);

		go.transform.position = new Vector3 (go.transform.position.x + 60, go.transform.position.y - posY, go.transform.position.z);
		
		var script = go.GetComponentInChildren<SetPatientToButton>();
		script.Patient = patient;

		var temp = go.GetComponentInChildren<Text>();
		temp.text = patient.persona.nomePessoa;
	}

	public void Awake ()
	{
		List<Paciente> patients = Paciente.Read();

		foreach (var patient in patients)
		{
			ButtonSpawner(heightOffset, patient);
			heightOffset += HEIGHT_PADDING;
		}

	}
}
