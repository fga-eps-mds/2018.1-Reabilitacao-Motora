using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPopUpManager : MonoBehaviour {

	[SerializeField]
	protected Button deleteButton;
	
	// Use this for initialization
	public void Start () 
	{
		var popUpManager = GameObject.Find("PopUp Manager");
		PopUpSpawner script = popUpManager.GetComponent(typeof(PopUpSpawner)) as PopUpSpawner;
		deleteButton.onClick.AddListener(script.Spawner);
	}
	
}
