using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using movimento;
using UnityEngine.SceneManagement;


public class SetMovementToButton : MonoBehaviour 
{

	private Movimento movement;

	public void SelectMovement ()
	{
		GlobalController.instance.movement = movement;
		SceneManager.LoadScene("Graphs2");
	}

	public Movimento Movement
	{
		get 
		{ 
			return movement;
		}
		set 
		{ 
			movement = value; 
		}
	}
}
