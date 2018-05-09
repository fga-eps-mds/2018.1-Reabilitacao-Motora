using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using exercicio;
using UnityEngine.SceneManagement;


public class SetExerciseToButton : MonoBehaviour 
{

	private Exercicio exercise;

	public void SelectExercise ()
	{
		GlobalController.instance.exercise = exercise;
	}

	public Exercicio Exercise
	{
		get 
		{
			return exercise;
		}
		set 
		{
			exercise = value; 
		}
	}
}
