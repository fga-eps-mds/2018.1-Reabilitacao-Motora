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
	protected Transform pointPrefab, mao, cotovelo, ombro, braco;
	float current_time_movement;
	bool t;

	LineRenderer lineRenderer;
	private static readonly Color c1 = Color.black;
	private static readonly Color c2 = Color.blue;

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

	public void Awake()
	{	
		t = false;
		current_time_movement = 0;
		var go = gameObject;
		
		GetMovementPoints.LoadLineRenderer(ref go, ref lineRenderer, c1, c2);
	}
}
