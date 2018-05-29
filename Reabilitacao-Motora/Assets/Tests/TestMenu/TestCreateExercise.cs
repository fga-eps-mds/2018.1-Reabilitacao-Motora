using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine.EventSystems;
using Mono.Data.Sqlite;

using exercicio;
using pessoa;
using paciente;
using fisioterapeuta;
using sessao;
using movimento;

/**
 * Cria um novo paciente no banco de dados.
 */
namespace Tests
{
	public static class TestCreateExercise
	{
		[SetUp]
		public static void BeforeEveryTest ()
		{
			GlobalController.test = true;
			GlobalController.Initialize();
		}

		/**
		 * Salva o paciente no banco.
		 */
		[UnityTest]
		public static IEnumerator TestSaveExercise()
		{
			Flow.StaticLogin();

			yield return new WaitForSeconds(2f);

			Pessoa.Insert("patient name1", "m", "1995-01-01", "6198732711", null);
			Pessoa.Insert("physio name1", "m", "1995-01-03", "6198732713", null);
			Fisioterapeuta.Insert(2, "abracadabra1", "demais1", null, null);
			Paciente.Insert(1, null);
			Movimento.Insert (1,"levantamento de peso", "asuhasu/caminhoy.com", null);
			Sessao.Insert (1, 1, "1940-10-10", null);

			var pacient = Paciente.Read();
			var fisio = Fisioterapeuta.Read();
			var moves = Movimento.Read();
			var sessions = Sessao.Read();

			GlobalController.instance.user = pacient[pacient.Count - 1];
			GlobalController.instance.admin = fisio[fisio.Count - 1];
			GlobalController.instance.movement = moves[moves.Count - 1];
			GlobalController.instance.session = sessions[sessions.Count - 1];

			Flow.StaticMovementsToExercise();

			yield return new WaitForSeconds(2f);

			createExercise.CreateExercise();

			yield return new WaitForSeconds(2f);

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "ChoiceSensor";

			var exer = Exercicio.Read();

			Assert.AreEqual(currentscene, expectedscene);
			Assert.AreEqual(GlobalController.instance.exercise.idExercicio, exer[exer.Count - 1].idExercicio);
		}

		[TearDown]
		public static void AfterEveryTest ()
		{
			SqliteConnection.ClearAllPools();
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GlobalController.DropAll();
		}
	}
}
