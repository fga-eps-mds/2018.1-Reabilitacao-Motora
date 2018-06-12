using System;
using System.Text.RegularExpressions;
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

using pessoa;
using fisioterapeuta;
using paciente;
using musculo;
using movimento;
using sessao;
using exercicio;
using movimentomusculo;
using pontosrotulofisioterapeuta;
using pontosrotulopaciente;

namespace Tests
{
	public static class TestDelete
	{
		[SetUp]
		public static void BeforeEveryTest ()
		{
			GlobalController.test = true;
			GlobalController.Initialize();
		}

		//unitário
		[UnityTest]
		public static IEnumerator TestDeletePhysio()
		{
			Flow.StaticLogin();
			Flow.StaticNewPhysiotherapistAdm();

			yield return null;
			
			var objectPhysio = GameObject.Find("Physiotherapist Manager");
			var physioManager = objectPhysio.GetComponentInChildren<createPhysiotherapist>();

			InputField aux = (InputField)physioManager.GetMemberValue("namePhysio");
			aux.text = "Fake Name";
			physioManager.SetMemberValue("namePhysio", aux);

			Text aux1 = (Text)physioManager.GetMemberValue("outDate");
			aux1.text = "01/01/1920";
			physioManager.SetMemberValue("outDate", aux1);
			
			InputField aux3 = (InputField)physioManager.GetMemberValue("phone1");
			aux3.text = "61999999";
			physioManager.SetMemberValue("phone1", aux3);

			InputField aux7 = (InputField)physioManager.GetMemberValue("login");
			aux7.text = "fake_login";
			physioManager.SetMemberValue("login", aux7);

			InputField aux8 = (InputField)physioManager.GetMemberValue("pass");
			aux8.text = "fake_pass";
			physioManager.SetMemberValue("pass", aux8);

			InputField aux9 = (InputField)physioManager.GetMemberValue("confirmPass");
			aux9.text = "fake_pass";
			physioManager.SetMemberValue("confirmPass", aux9);

			Toggle aux2 = (Toggle)physioManager.GetMemberValue("male");
			aux2.isOn = true;
			physioManager.SetMemberValue("male", aux2);

			Toggle aux0 = (Toggle)physioManager.GetMemberValue("female");
			aux0.isOn = false;
			physioManager.SetMemberValue("female", aux0);

			physioManager.savePhysiotherapist();

			int IdFisioterapeuta = GlobalController.instance.admin.idFisioterapeuta;
			int IdPessoa = GlobalController.instance.admin.persona.idPessoa;

			yield return new WaitForSeconds(0.5f);

			DeletePhysioButton.DeletePhysiotherapist();

			yield return new WaitForSeconds(0.5f);

			var allMovements = Movimento.Read();
			foreach (var movs in allMovements)
			{
				Assert.AreNotEqual(movs.idFisioterapeuta, IdFisioterapeuta);
			}

			var allSessions = Sessao.Read();
			foreach (var ses in allSessions)
			{
				Assert.AreNotEqual(ses.idFisioterapeuta, IdFisioterapeuta);
			}

			var allPhysios = Fisioterapeuta.Read();
			foreach (var physio in allPhysios)
			{
				Assert.AreNotEqual(physio.idFisioterapeuta, IdFisioterapeuta);
			}			

			string nomePessoa = (GlobalController.instance.admin.persona.nomePessoa).Replace(' ', '_');
			string nomePasta = string.Format("{0}/Movimentos/{1}-{2}", Application.dataPath, IdPessoa, nomePessoa);
			bool dir = System.IO.Directory.Exists(nomePasta);

			Assert.AreEqual (dir, false);
		}

		[UnityTest]
		public static IEnumerator TestDeleteExercise()
		{
			Flow.StaticLogin();

			yield return new WaitForSeconds(0.5f);

			Pessoa.Insert("patient name1", "m", "1995-01-01", "6198732711", null);
			Pessoa.Insert("physio name1", "m", "1995-01-03", "6198732713", null);
			Fisioterapeuta.Insert(2, "abracadabra1", "demais1", null, null);
			Paciente.Insert(1, null);
			Movimento.Insert (1,"levantamento de peso", "asuhasu/caminhoy.com", null);
			Sessao.Insert (1, 1, "1940-10-10", null);

			var pacient = Paciente.GetLast();
			var fisio = Fisioterapeuta.GetLast();
			var moves = Movimento.GetLast();
			var sessions = Sessao.GetLast();

			GlobalController.instance.user = pacient;
			GlobalController.instance.admin = fisio;
			GlobalController.instance.movement = moves;
			GlobalController.instance.session = sessions;

			Flow.StaticMovementsToExercise();

			yield return new WaitForSeconds(0.5f);

			createExercise.CreateExercise();

			var device = @"^(.*?(\bDevice|SDK\b)[^$]*)$";
			Regex rgx1 = new Regex(device, RegexOptions.IgnoreCase);
			LogAssert.Expect(LogType.Error, rgx1);

			yield return new WaitForSeconds(0.5f);

			DeleteExerciseButton.DeleteExercise();

			yield return new WaitForSeconds(0.5f);

			int IdExercicio = GlobalController.instance.exercise.idExercicio;

			List<PontosRotuloPaciente> allPrps = PontosRotuloPaciente.Read();

			foreach (var prp in allPrps)
			{
				Assert.AreNotEqual(prp.idExercicio, IdExercicio);
			}

			var exers = Exercicio.Read();
			foreach (var exer in exers)
			{
				Assert.AreNotEqual(exer.idExercicio, IdExercicio);
			}

			string pathEx = string.Format("{0}/Exercicios/{1}", Application.dataPath, GlobalController.instance.exercise.pontosExercicio);
			bool dir = System.IO.File.Exists(pathEx);

			Assert.AreEqual (dir, false);
		}

		[UnityTest]
		public static IEnumerator TestDeleteSession()
		{
			Flow.StaticLogin();

			yield return new WaitForSeconds(0.5f);

			Pessoa.Insert("patient name1", "m", "1995-01-01", "6198732711", null);
			Pessoa.Insert("physio name1", "m", "1995-01-03", "6198732713", null);
			Fisioterapeuta.Insert(2, "abracadabra1", "demais1", null, null);
			Paciente.Insert(1, null);

			var pacient = Paciente.GetLast();
			var fisio = Fisioterapeuta.GetLast();

			GlobalController.instance.user = pacient;
			GlobalController.instance.admin = fisio;

			Flow.StaticSessions();

			yield return new WaitForSeconds(0.5f);

			createSession.CreateSessao();

			yield return new WaitForSeconds(0.5f);

			DeleteSessionButton.DeleteSession();

			yield return new WaitForSeconds(0.5f);

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Sessions";

			Assert.AreEqual(expectedscene, currentscene);

			int IdSessao = GlobalController.instance.session.idSessao;

			var exers = Exercicio.Read();
			foreach (var exer in exers)
			{
				Assert.AreNotEqual(exer.idSessao, IdSessao);
			}

			var sess = Sessao.Read();
			foreach (var ses in sess)
			{
				Assert.AreNotEqual(ses.idSessao, IdSessao);
			}
		}


		[UnityTest]
		public static IEnumerator TestDeleteMovement()
		{
			Flow.StaticLogin();

			yield return new WaitForSeconds(1f);

			Pessoa.Insert("physio name1", "m", "1995-01-01", "6198732711", null);
			Fisioterapeuta.Insert(1, "abracadabra1", "demais1", null, null);

			var fisio = Fisioterapeuta.GetLast();

			GlobalController.instance.admin = fisio;

			Flow.StaticNewMovement();

			yield return new WaitForSeconds(1f);
			var moveManager = GameObject.Find("/New Movement Manager").GetComponentInChildren<createMovement>();

			InputField aux = (InputField)moveManager.GetMemberValue("nomeMovimento");
			aux.text = "Fake Name";
			moveManager.SetMemberValue("nomeMovimento", aux);

			InputField aux1 = (InputField)moveManager.GetMemberValue("musculos");
			aux1.text = "Deltoide";
			moveManager.SetMemberValue("musculos", aux1);

			InputField aux3 = (InputField)moveManager.GetMemberValue("descricao");
			aux3.text = "Ahaha seloco";
			moveManager.SetMemberValue("descricao", aux3);

			moveManager.saveMovement();

			var device = @"^(.*?(\bDevice|SDK\b)[^$]*)$";
			Regex rgx1 = new Regex(device, RegexOptions.IgnoreCase);
			LogAssert.Expect(LogType.Error, rgx1);

			yield return new WaitForSeconds(1f);

			DeleteMovementButton.DeleteMovement();

			yield return new WaitForSeconds(0.5f);

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Movements";

			Assert.AreEqual(expectedscene, currentscene);

			int IdMovimento = GlobalController.instance.movement.idMovimento;

			var prfs = PontosRotuloFisioterapeuta.Read();
			foreach (var prf in prfs)
			{
				Assert.AreNotEqual(prf.idMovimento, IdMovimento);
			}

			var exers = Exercicio.Read();
			foreach (var exer in exers)
			{
				Assert.AreNotEqual(exer.idMovimento, IdMovimento);
			}

			var mms = MovimentoMusculo.Read();
			foreach (var mm in mms)
			{
				Assert.AreNotEqual(mm.idMovimento, IdMovimento);
			}

			var movements = Movimento.Read();
			foreach (var movement in movements)
			{
				Assert.AreNotEqual(movement.idMovimento, IdMovimento);
			}

			string pathMov = string.Format("{0}/Movimentos/{1}", Application.dataPath, GlobalController.instance.movement.pontosMovimento);

			bool dir = System.IO.File.Exists(pathMov);

			Assert.AreEqual (dir, false);
		}

		[UnityTest]
		public static IEnumerator TestDeletePatient()
		{
			Flow.StaticLogin();
			Flow.StaticNewPatient();

			yield return null;

			var objectPatient = GameObject.Find("Patient Manager");
			var PatientManager = objectPatient.GetComponentInChildren<createPatient>();

			InputField aux = (InputField)PatientManager.GetMemberValue("namePatient");
			aux.text = "Fake Name";
			PatientManager.SetMemberValue("namePatient", aux);

			Text aux1 = (Text)PatientManager.GetMemberValue("outDate");
			aux1.text = "01/01/1920";
			PatientManager.SetMemberValue("outDate", aux1);

			InputField aux3 = (InputField)PatientManager.GetMemberValue("phone1");
			aux3.text = "61999999";
			PatientManager.SetMemberValue("phone1", aux3);

			InputField aux8 = (InputField)PatientManager.GetMemberValue("notes");
			aux8.text = "lorem ipsum";
			PatientManager.SetMemberValue("notes", aux8);

			Toggle aux2 = (Toggle)PatientManager.GetMemberValue("male");
			aux2.isOn = true;
			PatientManager.SetMemberValue("male", aux2);

			Toggle aux0 = (Toggle)PatientManager.GetMemberValue("female");
			aux0.isOn = false;
			PatientManager.SetMemberValue("female", aux0);

			PatientManager.savePatient();

			int IdPaciente = GlobalController.instance.user.idPaciente;
			int IdPessoa = GlobalController.instance.user.persona.idPessoa;

			yield return new WaitForSeconds(0.5f);

			DeletePatientButton.DeletePatient();

			yield return new WaitForSeconds(0.5f);

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "NewPatient";

			Assert.AreEqual(expectedscene, currentscene);

			var patients = Paciente.Read();
			foreach (var patient in patients)
			{
				Assert.AreNotEqual(patient.idPaciente, IdPaciente);
			}

			var exers = Exercicio.Read();
			foreach (var exer in exers)
			{
				Assert.AreNotEqual(exer.idPaciente, IdPaciente);
			}

			var sess = Sessao.Read();
			foreach (var ses in sess)
			{
				Assert.AreNotEqual(ses.idPaciente, IdPaciente);
			}

			var ppls = Pessoa.Read();
			foreach (var ppl in ppls)
			{
				Assert.AreNotEqual(ppl.idPessoa, IdPessoa);
			}

			string nomePessoa = (GlobalController.instance.user.persona.nomePessoa).Replace(' ', '_');
			string nomePasta = string.Format("Assets/Exercicios/{1}-{2}", Application.dataPath, IdPessoa, nomePessoa);

			bool dir = System.IO.Directory.Exists(nomePasta);

			Assert.AreEqual (dir, false);
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
