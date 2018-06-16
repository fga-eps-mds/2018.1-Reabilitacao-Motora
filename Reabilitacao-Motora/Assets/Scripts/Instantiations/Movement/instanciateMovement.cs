using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using movimento;
using DataBaseAttributes;

public class instanciateMovement : MonoBehaviour 
{
	[SerializeField]
	protected GameObject buttonPrefab;

	[SerializeField]
	protected InputField searchInput;

	const int HEIGHT_PADDING = 55;

	public void Start()
    {
        /*
         * Trata de ouvir as modificacoes no campo.
         */
        searchInput.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
    }


	/*
     * Esta funcao eh chamada quando se alteram os valores do campo.
     */
    public void ValueChangeCheck()
    {
		ClearScreen();
		if(searchInput.text == "")
		{
			init();
		}
		else
		{
			var query = string.Format("select * from MOVIMENTO INNER JOIN MOVIMENTOMUSCULO ON MOVIMENTO.idMovimento = MOVIMENTOMUSCULO.idMovimento INNER JOIN MUSCULO ON MOVIMENTOMUSCULO.idMusculo = MUSCULO.idMusculo AND (MOVIMENTO.nomeMovimento LIKE '%{0}%' or MUSCULO.nomeMusculo LIKE '%{1}%')", searchInput.text, searchInput.text);
			List<Movimento> movements = Movimento.MultiSpecificSelect(query);
			int heightOffset = 10;
			foreach (var movement in movements)
			{
				ButtonSpawner(heightOffset, movement);
				heightOffset += HEIGHT_PADDING;
			}
		}
	}

	public void ClearScreen()
	{
		var allMovements = GameObject.FindGameObjectsWithTag("movimentPrefab");
		
		foreach (var movement in allMovements)
		{
			Destroy(movement);
		}
	}

	public void ButtonSpawner(int posY, Movimento movement)
	{
		GameObject go = Instantiate(buttonPrefab, transform);

		go.transform.position = new Vector3 (go.transform.position.x, go.transform.position.y - posY, go.transform.position.z);
		var aux = go.GetComponentInChildren<SetMovementToButton>();
		aux.Movement = movement;

		var temp = go.GetComponentInChildren<Text>();
		temp.text = movement.nomeMovimento;

		Debug.Log(temp.text);
	}

	public void Awake ()
	{
		init();
	}

	public void init ()
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
