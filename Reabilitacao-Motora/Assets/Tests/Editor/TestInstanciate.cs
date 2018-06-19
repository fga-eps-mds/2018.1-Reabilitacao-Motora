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


namespace Tests
{
	public static class TestInstanciate
	{
		[SetUp]
		public static void BeforeEveryTest ()
		{
			GlobalController.test = true;
			GlobalController.Initialize();
		}

		public static int CountGameObjectsWithSameName (string name)
		{
		    GameObject[] allObjs = UnityEngine.Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];
		    List<GameObject> likeNames = new List<GameObject>();
		    foreach (GameObject obj in allObjs)
		    {
		        if (obj.name == name)
		        {
		            likeNames.Add(obj);
		        }
		    }
		    return likeNames.Count;
		}

		//unitário
		[Test]
		public static void TestInstanciatePhysio()
		{	
			Pessoa.Insert("physio name1", "m", "1995-01-03", "6198732713", null);
			Fisioterapeuta.Insert(1, "abracadabra1", "demais1", null, null);

			var fisios = Fisioterapeuta.GetLast();

			UnityEditor.SceneManagement.EditorSceneManager.OpenScene(Application.dataPath + "/Scenes/NewPhysiotherapist Adm.unity");

			var panelphysio = GameObject.Find("PanelMoves");
			var instanciate = panelphysio.GetComponentInChildren<instanciatePhysiotherapist>();
			instanciate.ButtonSpawner(0, fisios);
			int countPhysios = CountGameObjectsWithSameName("PhysioPrefab(Clone)");

			Assert.AreEqual(1, countPhysios);
		}

		[Test]
		public static void TestInstanciateExercise()
		{
			Pessoa.Insert("patient name1", "m", "1995-01-01", "6198732711", null);
			Pessoa.Insert("physio name1", "m", "1995-01-03", "6198732713", null);
			Fisioterapeuta.Insert(2, "abracadabra1", "demais1", null, null);
			Paciente.Insert(1, null);
			Movimento.Insert (1,"levantamento de peso", "asuhasu/caminhoy.com", null);
			Sessao.Insert (1, 1, "1940-10-10", null);

			var pacient = Paciente.GetLast();
			var moves = Movimento.GetLast();
			var sessions = Sessao.GetLast();

			Exercicio.Insert(pacient.idPaciente, moves.idMovimento, sessions.idSessao, "2-Tanto_Fazm/2018-05-30-18-33/24-Ahaha_Hahaha-182944.points", null);
			
			UnityEditor.SceneManagement.EditorSceneManager.OpenScene(Application.dataPath + "/Scenes/ExercisesToReview.unity");

			var panelphysio = GameObject.Find("Content");
			var instanciate = panelphysio.GetComponentInChildren<instanciateExercise>();

			var exers = Exercicio.GetLast();
			instanciate.ButtonSpawner(60, exers);
			int countExers = CountGameObjectsWithSameName("Exercise da Reproduce Exercise(Clone)");

			Assert.AreEqual(1, countExers);
		}

		[Test]
		public static void TestInstanciateSession()
		{
			Pessoa.Insert("patient name1", "m", "1995-01-01", "6198732711", null);
			Pessoa.Insert("physio name1", "m", "1995-01-03", "6198732713", null);
			Fisioterapeuta.Insert(2, "abracadabra1", "demais1", null, null);
			Paciente.Insert(1, null);

			var fisio = Fisioterapeuta.GetLast();
			var pacient = Paciente.GetLast();

			Sessao.Insert(fisio.idFisioterapeuta, pacient.idPaciente, "10-10-1990-15-10", null);

			var sess = Sessao.GetLast();

			UnityEditor.SceneManagement.EditorSceneManager.OpenScene(Application.dataPath + "/Scenes/Patient.unity");

			var panelsess = GameObject.Find("PanelShowSessions");
			var instanciate = panelsess.GetComponentInChildren<instanciateSession>();
			instanciate.ButtonSpawner(0, sess);
			int countSess = CountGameObjectsWithSameName("SessionPrefab(Clone)");

			Assert.AreEqual(1, countSess);
		}


		[Test]
		public static void TestInstanciateMovement()
		{
			Pessoa.Insert("physio name1", "m", "1995-01-01", "6198732711", null);
			Fisioterapeuta.Insert(1, "abracadabra1", "demais1", null, null);

			var fisio = Fisioterapeuta.GetLast();

			Movimento.Insert(fisio.idFisioterapeuta, "Ascensao do Braco", "1-Davi_Golias/Ahaha_Hahaha-182944.points", null);

			UnityEditor.SceneManagement.EditorSceneManager.OpenScene(Application.dataPath + "/Scenes/Movements.unity");

			var panelmove = GameObject.Find("Canvas");
			var instanciate = panelmove.GetComponentInChildren<instanciateMovement>();

			var moves = Movimento.GetLast();

			instanciate.ButtonSpawner(0, moves);
			int countMoves = CountGameObjectsWithSameName("MovimentoMovements(Clone)");

			Assert.AreEqual(1, countMoves);
		}

		[Test]
		public static void TestInstanciatePatient()
		{
			Pessoa.Insert("patient name1", "m", "1995-01-01", "6198732711", null);
			Pessoa.Insert("physio name1", "m", "1995-01-03", "6198732713", null);
			Fisioterapeuta.Insert(2, "abracadabra1", "demais1", null, null);
			Paciente.Insert(1, null);

			var patients = Paciente.GetLast();

			UnityEditor.SceneManagement.EditorSceneManager.OpenScene(Application.dataPath + "/Scenes/NewPatient.unity");

			var panelPatient = GameObject.Find("Canvas");
			var instanciate = panelPatient.GetComponentInChildren<instanciatePatient>();
			instanciate.ButtonSpawner(0, patients);
			int countPatients = CountGameObjectsWithSameName("PatientPrefab(Clone)");

			Assert.AreEqual(1, countPatients);
		}

		[TearDown]
		public static void AfterEveryTest ()
		{
			SqliteConnection.ClearAllPools();
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GlobalController.DropAll();
			GlobalController.instance = null;
		}
	}
}
