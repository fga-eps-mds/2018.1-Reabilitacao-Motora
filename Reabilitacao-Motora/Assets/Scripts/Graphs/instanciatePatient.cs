using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using paciente;

public class instanciatePatient : MonoBehaviour {

	public GameObject buttonPrefab;
	string path;
	Paciente tablePaciente;
	List<Paciente.Pacientes> values;

	int z = 10;

	void MyAwesomeCreator(int posy, Paciente.Pacientes r)
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
		path = "URI=file:" + Application.dataPath + "/Plugins/fisiotech.db";

		Initialize ();

		values = tablePaciente.Read();

		foreach (var l in values)
		{
			MyAwesomeCreator(z, l);
			z += 55;
		}

	}

	void Initialize()
	{
	    tablePaciente = new Paciente(path);
	    values = new List<Paciente.Pacientes>();
	}
}
