using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using exercicio;

public class instanciateExercise : MonoBehaviour 
{

	public GameObject buttonPrefab;

	int heightOffset = 60;
	const int HEIGHT_PADDING = 55;

	void ButtonSpawner(int posY, Exercicio exercise)
	{
		GameObject go = Instantiate(buttonPrefab, transform);

		go.transform.position = new Vector3 (go.transform.position.x + 60, go.transform.position.y - posY, go.transform.position.z);
		
		var script = go.GetComponentInChildren<SetExerciseToButton>();
		script.Exercise = exercise;

		var temp = go.GetComponentInChildren<Text>();
		temp.text = exercise.pontosExercicio;
	}

	public void Awake ()
	{
		List<Exercicio> exercises = Exercicio.Read();

		foreach (var exercise in exercises)
		{
			ButtonSpawner(heightOffset, exercise);
			heightOffset += HEIGHT_PADDING;
		}

	}
}
