using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPopUpManager : MonoBehaviour {

	private Button DeleteButton;

	public Button deleteButton
	{
		get
		{
			return DeleteButton;
		}
		set
		{
			DeleteButton = value;
		}
	}

	// Use this for initialization
	void Start () 
	{
		var popUpManager = GameObject.Find("PopUp Manager");
		PopUpSpawner script = popUpManager.GetComponent(typeof(PopUpSpawner)) as PopUpSpawner;
		deleteButton.onClick.AddListener(script.Spawner);
	}
	
}
