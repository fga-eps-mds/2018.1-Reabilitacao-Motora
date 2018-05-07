using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using paciente;
using UnityEngine.SceneManagement;
using sessao;
using exercicio;
using pontosrotulopaciente;

public class DeletePatientButton : MonoBehaviour {

	public void DeletePatient ()
	{
		int IdPaciente = GlobalController.instance.user.idPaciente;

		List<Sessao> allSessions = Sessao.Read();
		List<Exercicio> allExercises = Exercicio.Read();
		List<PontosRotuloPaciente> allPrps = PontosRotuloPaciente.Read();

		foreach (var exercise in allExercises)
		{
			if (exercise.idPaciente == IdPaciente)
			{
				foreach (var prp in allPrps)
				{
					if (prp.idExercicio == exercise.idExercicio)
					{
						PontosRotuloPaciente.DeleteValue (prp.idRotuloPaciente);
					}
				}

				Exercicio.DeleteValue (exercise.idExercicio);
			}
		}

		foreach (var session in allSessions)
		{
			if (session.idPaciente == IdPaciente)
			{
				Sessao.DeleteValue (session.idSessao);
			}
		}

		Paciente.DeleteValue(IdPaciente);

		Flow.StaticNewPatient();
	}

}
