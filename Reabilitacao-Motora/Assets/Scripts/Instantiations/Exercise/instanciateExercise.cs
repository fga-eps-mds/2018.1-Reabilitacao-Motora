using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using exercicio;

public class instanciateExercise : MonoBehaviour 
{
	[SerializeField]
	protected GameObject buttonPrefab;

	const int HEIGHT_PADDING = 55;

	public void ButtonSpawner(int posY, Exercicio exercise)
	{
		GameObject go = Instantiate(buttonPrefab, transform);
		go.transform.position = new Vector3 (go.transform.position.x + 60, go.transform.position.y - posY, go.transform.position.z);
		
		var script = go.GetComponentInChildren<SetExerciseToButton>();
		script.Exercise = exercise;

		var temp = go.GetComponentInChildren<Text>();
		temp.text = formatName(exercise.pontosExercicio);
	}


	public void Start ()
	{
		if (GlobalController.instance.session != null)
		{
			List<Exercicio> exercises = Exercicio.Read();
			int heightOffset = 60;
			foreach (var exercise in exercises)
			{
				if (exercise.idSessao == GlobalController.instance.session.idSessao)
				{
					ButtonSpawner(heightOffset, exercise);
					heightOffset += HEIGHT_PADDING;
				}
			}
		}
	}


	public static string formatName (string pontosExercicio)
	{
		var partsBetweenSlashs = pontosExercicio.Split('/');
		var partsBetweenDashs = partsBetweenSlashs[2].Split('-');
		var withoutUnderscores = partsBetweenDashs[0].Replace('_', ' ');
		var result = string.Format("{0}{1}", partsBetweenDashs[1], withoutUnderscores); 
		return result;
	}
}
