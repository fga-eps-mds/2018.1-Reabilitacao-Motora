using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using paciente;

public class instanciatePatient : MonoBehaviour 
{

	public GameObject buttonPrefab;

	int heightOffset = 10;
	const int HEIGHT_PADDING = 55;

	void ButtonSpawner(int posY, Paciente patient)
	{
		GameObject go = Instantiate(buttonPrefab, transform);

		go.transform.position = new Vector3 (go.transform.position.x, go.transform.position.y - posY, go.transform.position.z);
		var aux = go.GetComponentInChildren<SetPatientToButton>();
		aux.Patient = patient;

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
