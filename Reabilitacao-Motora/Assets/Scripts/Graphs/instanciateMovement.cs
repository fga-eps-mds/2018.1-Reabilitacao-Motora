using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using movimento;

public class instanciateMovement : MonoBehaviour {

	public GameObject buttonPrefab;
	string path;
	Movimento tableMovimento;
	List<Movimento.Movimentos> values;

	int z = 10;

	void MyAwesomeCreator(int posy, Movimento.Movimentos r)
	{
		GameObject go = Instantiate(buttonPrefab, transform);

		var button = GetComponent<UnityEngine.UI.Button>();
		go.transform.position = new Vector3 (go.transform.position.x, go.transform.position.y - posy, go.transform.position.z);
		var aux = go.GetComponentInChildren<setmovement>();
		aux.x = r;

		var temp = go.GetComponentInChildren<Text>();
		temp.text = r.nomeMovimento;
	}

	public void Awake ()
	{
		path = "URI=file:" + Application.dataPath + "/Plugins/fisiotech.db";

		Initialize ();

		values = tableMovimento.Read();

		foreach (var l in values)
		{
			print (string.Format("{0}", l.nomeMovimento));
			MyAwesomeCreator(z, l);
			z += 55;
		}

	}

	void Initialize()
	{
	    tableMovimento = new Movimento(path);
	    values = new List<Movimento.Movimentos>();
	}
}
