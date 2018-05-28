using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPopUpManagerFisioValidation : MonoBehaviour {

	[SerializeField]
	protected Button saveButton;

	public void Start ()
	{
		var popUpManagerValidation = GameObject.Find("/PopUp Validation Manager");
		PopUpSpawnerValidation script = popUpManagerValidation.GetComponent(typeof(PopUpSpawnerValidation)) as PopUpSpawnerValidation;
		saveButton.onClick.AddListener(script.Spawner);
	}

}
