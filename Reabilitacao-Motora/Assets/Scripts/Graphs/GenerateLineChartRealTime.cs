using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
* Descrever aqui o que essa classe realiza.
*/
public class GenerateLineChartRealTime : MonoBehaviour
{
	[SerializeField]
	protected Transform pointPrefab;
	protected Transform mao, cotovelo, ombro, braco;
	float current_time_movement;
	bool t;

	[System.Serializable]
	public class NecessaryJoints
	{
		public Transform ombroAux, bracoAux, cotoveloAux, maoAux;
	}

	[SerializeField]
	protected NecessaryJoints[] joints;

	public void Assign ()
	{
		if (GlobalController.choiceAvatar == 1)
		{
			ombro = joints[0].ombroAux;
			braco = joints[0].bracoAux;
			cotovelo = joints[0].cotoveloAux;
			mao = joints[0].maoAux;
		}
		else if (GlobalController.choiceAvatar == 2)
		{
			ombro = joints[1].ombroAux;
			braco = joints[1].bracoAux;
			cotovelo = joints[1].cotoveloAux;
			mao = joints[1].maoAux;
		}
		else if (GlobalController.choiceAvatar == 3)
		{
			ombro = joints[2].ombroAux;
			braco = joints[2].bracoAux;
			cotovelo = joints[2].cotoveloAux;
			mao = joints[2].maoAux;
		}
		else if (GlobalController.choiceAvatar == 4)
		{
			ombro = joints[3].ombroAux;
			braco = joints[3].bracoAux;
			cotovelo = joints[3].cotoveloAux;
			mao = joints[3].maoAux;
		}
		else if (GlobalController.choiceAvatar == 5)
		{
			ombro = joints[4].ombroAux;
			braco = joints[4].bracoAux;
			cotovelo = joints[4].cotoveloAux;
			mao = joints[4].maoAux;
		}
	}

	LineRenderer lineRenderer;
	private static readonly Color c1 = Color.black;
	private static readonly Color c2 = Color.red;
	private static readonly Color c3 = Color.blue;

	public void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			t = !t;
		}
	}

	public void FixedUpdate()
	{
		if (t) 
		{
			current_time_movement += Time.fixedDeltaTime;

			if (GlobalController.patientOrPhysio)
			{
				GetMovementPoints.SavePoints (current_time_movement,
					"/Movimentos/", 
					GlobalController.instance.movement.pontosMovimento,
					mao, 
					cotovelo,
					ombro, 
					braco);
			}
			else
			{
				GetMovementPoints.SavePoints (current_time_movement,
					"/Exercicios/", 
					GlobalController.instance.exercise.pontosExercicio,
					mao, 
					cotovelo,
					ombro, 
					braco);
			}

			if (current_time_movement >= 15f) 
			{
				t = false;
			}

			GetMovementPoints.graphSpawner(transform, pointPrefab, mao, cotovelo, ombro, current_time_movement, ref lineRenderer);
		}
	}

	public void Start()
	{	
		t = false;
		current_time_movement = 0;
		var go = gameObject;

		if (GlobalController.patientOrPhysio)
		{
			GetMovementPoints.LoadLineRenderer(ref go, ref lineRenderer, c1, c2);
		}
		else
		{
			GetMovementPoints.LoadLineRenderer(ref go, ref lineRenderer, c1, c3);
		}

		Assign();
	}
}
