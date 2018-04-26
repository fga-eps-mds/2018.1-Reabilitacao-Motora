using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using paciente;

public class instanciatePatient : MonoBehaviour {

	public GameObject buttonPrefab;

	List<Paciente> values;

	int z = 10;

	void MyAwesomeCreator(int posy, Paciente r)
	{
		GameObject go = Instantiate(buttonPrefab, transform);

		var button = GetComponent<UnityEngine.UI.Button>();
		go.transform.position = new Vector3 (go.transform.position.x, go.transform.position.y - posy, go.transform.position.z);
		var aux = go.GetComponentInChildren<setpatient>();
		aux.x = r;

		var temp = go.GetComponentInChildren<Text>();
		temp.text = r.persona.nomePessoa;
	}

	public void Awake ()
	{
		Initialize ();

		values = Paciente.Read();

		foreach (var l in values)
		{
			MyAwesomeCreator(z, l);
			z += 55;
		}

	}

	void Initialize()
	{
	    values = new List<Paciente>();
	}
}
