using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using paciente;
using sessao;
using pessoa;
using exercicio;
using pontosrotulopaciente;

public class DeletePatientButton : MonoBehaviour 
{

	public void DeletePatient ()
	{
		int IdPaciente = GlobalController.instance.user.idPaciente;
		int IdPessoa = GlobalController.instance.user.persona.idPessoa;

		string nomePessoa = (GlobalController.instance.user.persona.nomePessoa).Replace(' ', '_');
		string nomePasta = string.Format("{0}/Exercicios/{1}-{2}", Application.dataPath, IdPessoa, nomePessoa);

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
		Pessoa.DeleteValue(IdPessoa);

		Directory.Delete(nomePasta.Replace('/', '\\'), true);

		Flow.StaticNewPatient();
	}

}
