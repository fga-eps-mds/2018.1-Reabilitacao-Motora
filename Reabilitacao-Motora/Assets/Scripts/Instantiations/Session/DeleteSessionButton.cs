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
using sessao;

public class DeleteSessionButton : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{DeleteSession();});
	}

	public static void DeleteSession ()
	{
		int IdSessao = GlobalController.instance.session.idSessao;

		List<Exercicio> allExercises = Exercicio.Read();
		bool deleted = false;

		foreach (var exercise in allExercises)
		{
			if (exercise.idSessao == IdSessao)
			{
				GlobalController.instance.exercise = exercise;

				if (!deleted)
				{
					deleted = true;

					var slashedString = exercise.pontosExercicio.Split('/');
					var sessionFolderName = slashedString[1];
					
					string pathSession = string.Format("{0}/Exercicios/{1}", Application.dataPath, sessionFolderName);

					if(Directory.Exists(pathSession))
					{
						Directory.Delete(pathSession);
					}
				}

				DeleteExerciseButton.DeleteExercise();
			}
		}

		Sessao.DeleteValue (IdSessao);
		Flow.StaticSessions();
	}
}
