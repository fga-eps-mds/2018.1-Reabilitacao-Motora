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
		string query = string.Format("select * from MOVIMENTO WHERE idMovimento = {0}", exercise.idMovimento);
		Movimento mov = Movimento.SingleSpecificSelect(query);
		GlobalController.instance.movement = mov;
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
