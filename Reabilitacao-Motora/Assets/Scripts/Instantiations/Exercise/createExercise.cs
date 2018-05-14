using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using exercicio;

/**
 * Cria um novo paciente no banco de dados.
 */
public class createExercise : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{CreateExercise();});
	}
	/**
	 * Salva o paciente no banco.
	 */
	public static void CreateExercise()
	{
		string patientUnderscored = (GlobalController.instance.user.persona.nomePessoa).Replace(' ', '_');

		string pathSave = GlobalController.instance.user.idPessoa + "-";
		pathSave += patientUnderscored + "/";
		pathSave += GlobalController.instance.session.dataSessao + "/";

		var token = (GlobalController.instance.movement.pontosMovimento).Split('/');
		string date = DateTime.Now.ToString("ss", System.Globalization.DateTimeFormatInfo.InvariantInfo);

		pathSave += date + "-" + token[1] + ".points";

		Exercicio.Insert(GlobalController.instance.user.idPaciente, 
			GlobalController.instance.movement.idMovimento,
			GlobalController.instance.session.idSessao, 
			null, pathSave);

		List<Exercicio> exercises = Exercicio.Read();
		GlobalController.instance.exercise = exercises[exercises.Count - 1];

		Flow.StaticRealtimeGraph();
	}
}
