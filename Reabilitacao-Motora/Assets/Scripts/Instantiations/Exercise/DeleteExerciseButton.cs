using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using movimento;
using exercicio;
using movimentomusculo;
using pontosrotulofisioterapeuta;
using pontosrotulopaciente;

public class DeleteExerciseButton : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{DeleteExercise();});
	}

	public static void DeleteExercise ()
	{
		int IdExercicio = GlobalController.instance.exercise.idExercicio;

		List<PontosRotuloPaciente> allPrps = PontosRotuloPaciente.Read();


		foreach (var prp in allPrps)
		{
			if (prp.idExercicio == IdExercicio)
			{
				PontosRotuloPaciente.DeleteValue (prp.idRotuloPaciente);
			}
		}

		string pathEx = string.Format("{0}/Exercicios/{1}", Application.dataPath, GlobalController.instance.exercise.pontosExercicio);

		if(File.Exists(pathEx))
		{
			File.Delete(pathEx);
		}

		Exercicio.DeleteValue (IdExercicio);
	}
}
