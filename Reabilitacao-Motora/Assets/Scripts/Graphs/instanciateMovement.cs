using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using movimento;

public class instanciateMovement : MonoBehaviour 
{

	public GameObject buttonPrefab;

	int heightOffset = 10;

	void ButtonSpawner(int posy, Movimento movement)
	{
		GameObject go = Instantiate(buttonPrefab, transform);

		go.transform.position = new Vector3 (go.transform.position.x, go.transform.position.y - posy, go.transform.position.z);
		var aux = go.GetComponentInChildren<SetMovementToButton>();
		aux.Movement = movement;

		var temp = go.GetComponentInChildren<Text>();
		temp.text = movement.nomeMovimento;
	}

	public void Awake ()
	{
		List<Movimento> movements = Movimento.Read();

		foreach (var movement in movements)
		{
			ButtonSpawner(heightOffset, movement);
			heightOffset += 55;
		}

	}
}
