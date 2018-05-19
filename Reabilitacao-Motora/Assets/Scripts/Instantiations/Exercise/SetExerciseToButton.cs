using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using exercicio;
using movimento;
using UnityEngine.SceneManagement;


public class SetExerciseToButton : MonoBehaviour 
{

	private Exercicio exercise;

	public void SelectExercise ()
	{
		GlobalController.instance.exercise = exercise;
		List<Movimento> movements = Movimento.Read();
		foreach (var mov in movements)
		{
			if (mov.idMovimento == exercise.idMovimento)
			{
				GlobalController.instance.movement = mov;
			}
		}
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
