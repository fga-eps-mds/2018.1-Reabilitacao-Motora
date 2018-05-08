using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using sessao;

public class instanciateSession : MonoBehaviour 
{

	public GameObject buttonPrefab;

	int heightOffset = 10;
	const int HEIGHT_PADDING = 55;

	void ButtonSpawner(int posY, Sessao session)
	{
		GameObject go = Instantiate(buttonPrefab, transform);

		go.transform.position = new Vector3 (go.transform.position.x, go.transform.position.y - posY, go.transform.position.z);
		var aux = go.GetComponentInChildren<SetSessionToButton>();
		aux.Session = session;

		var temp = go.GetComponentInChildren<Text>();
		temp.text = session.dataSessao;
	}

	public void Awake ()
	{
		List<Sessao> sessions = Sessao.Read();

		foreach (var session in sessions)
		{
			if (session.idPaciente == GlobalController.instance.user.idPaciente)
			{
				ButtonSpawner(heightOffset, session);
				heightOffset += HEIGHT_PADDING;
			}
		}
	}
}
