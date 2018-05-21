using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using paciente;
using UnityEngine.SceneManagement;
using sessao;
using exercicio;
using fisioterapeuta;
using movimento;
using pontosrotulofisioterapeuta;
using movimentomusculo;

public class DeletePhysioButton : MonoBehaviour
{
		[SerializeField]
		protected Button nextPage;

		public void Awake ()
		{
			nextPage.onClick.AddListener(delegate{DeletePhysiotherapist();});
		}


	public static void DeletePhysiotherapist ()
	{
		int IdFisioterapeuta = GlobalController.instance.admin.idFisioterapeuta;
		int IdPessoa = GlobalController.instance.admin.persona.idPessoa;

		string nomePessoa = (GlobalController.instance.admin.persona.nomePessoa).Replace(' ', '_');
		string nomePasta = string.Format("{0}/Movimentos/{1}-{2}", Application.dataPath, IdPessoa, nomePessoa);

		List<Movimento> allMovements = Movimento.Read();
		List<Sessao> allSessions = Sessao.Read();
		List<PontosRotuloFisioterapeuta> allPRF = PontosRotuloFisioterapeuta.Read (); 
		List<Exercicio> allExercises = Exercicio.Read();
		List<MovimentoMusculo> allMovMuscles = MovimentoMusculo.Read ();

		foreach (var movements in allMovements)
		{
			if (movements.idFisioterapeuta == IdFisioterapeuta)
			{
				foreach (var prf in allPRF)
				{
					if (prf.idMovimento == movements.idMovimento)
					{
						PontosRotuloFisioterapeuta.DeleteValue (prf.idRotuloFisioterapeuta);
					}
				}

				foreach (var mvm in allMovMuscles)
				{
					if (mvm.idMovimento == movements.idMovimento)
					{
						MovimentoMusculo.DeleteValue (mvm.idMovimento, mvm.idMusculo);
					}
				}

				foreach (var execises in allExercises)
				{
					if (execises.idMovimento == movements.idMovimento)
					{
						Exercicio.DeleteValue (execises.idExercicio);
					}
				}

				Movimento.DeleteValue (movements.idMovimento);
			}
		}

		foreach (var session in allSessions)
		{
			if (session.idPaciente == IdFisioterapeuta)
			{
				Sessao.DeleteValue (session.idSessao);
			}
		}

		Fisioterapeuta.DeleteValue(IdFisioterapeuta);
		
		Directory.Delete(nomePasta.Replace('/', '\\'), true);

		Flow.StaticNewPhysiotherapist();
	}
}
