using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using movimento;
using exercicio;

public class instanciateMovementInSession : MonoBehaviour 
{
	[SerializeField]
	protected GameObject buttonPrefab;

	const int HEIGHT_PADDING = 55;

	void ButtonSpawner(int posY, Movimento movement)
	{
		GameObject go = Instantiate(buttonPrefab, transform);

		go.transform.position = new Vector3 (go.transform.position.x, go.transform.position.y - posY, go.transform.position.z);
		var aux = go.GetComponentInChildren<SetMovementToButton>();
		aux.Movement = movement;

		var temp = go.GetComponentInChildren<Text>();
		temp.text = movement.nomeMovimento;
	}

	public void Awake ()
	{
		if (GlobalController.instance.session != null)
		{
			string query = string.Format("select * from MOVIMENTO INNER JOIN EXERCICIO ON MOVIMENTO.idMovimento = EXERCICIO.idMovimento AND idSessao = {0}", GlobalController.instance.session.idSessao);
			List<Movimento> movements = Movimento.MultiSpecificSelect(query);

			int heightOffset = 10;
			foreach (var movement in movements)
			{
				ButtonSpawner(heightOffset, movement);
				heightOffset += HEIGHT_PADDING;
			}
		}
		else
		{
			Debug.Log("Você violou o acesso!");
		}
	}
}
