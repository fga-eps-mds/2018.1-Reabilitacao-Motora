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
		List<Movimento> movements = Movimento.Read();
		List<Exercicio> exercises = Exercicio.Read();

		int heightOffset = 10;
		foreach (var movement in movements)
		{
			foreach (var exercise in exercises)
			{
				if ((exercise.idMovimento == movement.idMovimento) && (exercise.idSessao == GlobalController.instance.session.idSessao))
				{
					ButtonSpawner(heightOffset, movement);
					heightOffset += HEIGHT_PADDING;
				}
			}
		}
	}
}
