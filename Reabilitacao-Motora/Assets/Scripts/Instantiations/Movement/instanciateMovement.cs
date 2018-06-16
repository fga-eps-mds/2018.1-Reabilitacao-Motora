using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using movimento;

public class instanciateMovement : MonoBehaviour 
{
	[SerializeField]
	protected GameObject buttonPrefab;

	const int HEIGHT_PADDING = 55;
	public void getMovs (string x)
	{
		var query = string.Format("select nomeMovimento from MOVIMENTO INNER JOIN MOVIMENTOMUSCULO ON MOVIMENTO.idMovimento = MOVIMENTOMUSCULO.idMovimento INNER JOIN MUSCULO ON MOVIMENTOMUSCULO.idMusculo = MUSCULO.idMusculo AND (MOVIMENTO.nomeMovimento LIKE '%{0}%'or MUSCULO.nomeMusculo LIKE '%{1}%')", x, x);
		List<Movimento> movements = Database.MultiSpecificSelect<Movimento>(query);
	}


	public void ButtonSpawner(int posY, Movimento movement)
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
		int heightOffset = 10;
		foreach (var movement in movements)
		{
			ButtonSpawner(heightOffset, movement);
			heightOffset += HEIGHT_PADDING;
		}

	}
}
