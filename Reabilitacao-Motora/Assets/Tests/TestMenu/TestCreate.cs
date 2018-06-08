using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
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
	public static class TestCreate
	{
		[SetUp]
		public static void BeforeEveryTest ()
		{
			GlobalController.test = true;
			GlobalController.Initialize();
		}

		[UnityTest]
		public static IEnumerator TestPhysioManagerInputFields()
		{
			Flow.StaticNewPhysiotherapist();

			yield return null;

			var objectPhysio = GameObject.Find("Physiotherapist Manager");
			var physioManager = objectPhysio.GetComponentInChildren<createPhysiotherapist>();

			Assert.AreNotEqual(null, physioManager.GetMemberValue("namePhysio"));
			Assert.AreNotEqual(null, physioManager.GetMemberValue("date"));
			Assert.AreNotEqual(null, physioManager.GetMemberValue("phone1"));
			Assert.AreNotEqual(null, physioManager.GetMemberValue("phone2"));
			Assert.AreNotEqual(null, physioManager.GetMemberValue("crefito"));
			Assert.AreNotEqual(null, physioManager.GetMemberValue("regiao"));
			Assert.AreNotEqual(null, physioManager.GetMemberValue("login"));
			Assert.AreNotEqual(null, physioManager.GetMemberValue("pass"));
			Assert.AreNotEqual(null, physioManager.GetMemberValue("confirmPass"));
			Assert.AreNotEqual(null, physioManager.GetMemberValue("male"));
			Assert.AreNotEqual(null, physioManager.GetMemberValue("female"));
			
		}

		//aceitação
		[UnityTest]
		public static IEnumerator TestPhysioSaveButton()
		{
			Flow.StaticLogin();
			Flow.StaticNewPhysiotherapist();

			yield return null;
			
			var objectPhysio = GameObject.Find("Physiotherapist Manager");
			var physioManager = objectPhysio.GetComponentInChildren<createPhysiotherapist>();

			var objectButton = GameObject.Find("Canvas/PanelPhysiotherapist/SaveBt");
			var button = objectButton.GetComponentInChildren<Button>();

			InputField aux = (InputField)physioManager.GetMemberValue("namePhysio");
			aux.text = "Fake Name";
			physioManager.SetMemberValue("namePhysio", aux);

			InputField aux1 = (InputField)physioManager.GetMemberValue("date");
			aux1.text = "01/01/1920";
			physioManager.SetMemberValue("date", aux1);
			
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

			button.OnPointerClick(new PointerEventData(EventSystem.current));

			yield return new WaitForSeconds(0.5f);

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Login";

			Assert.AreEqual(expectedscene, currentscene);
		}

		//unitário
		[UnityTest]
		public static IEnumerator TestSavePhysio()
		{
			Flow.StaticLogin();
			Flow.StaticNewPhysiotherapist();

			yield return null;
			
			var objectPhysio = GameObject.Find("Physiotherapist Manager");
			var physioManager = objectPhysio.GetComponentInChildren<createPhysiotherapist>();

			InputField aux = (InputField)physioManager.GetMemberValue("namePhysio");
			aux.text = "Fake Name";
			physioManager.SetMemberValue("namePhysio", aux);

			InputField aux1 = (InputField)physioManager.GetMemberValue("date");
			aux1.text = "01/01/1920";
			physioManager.SetMemberValue("date", aux1);
			
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

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Login";

			var fisios = Fisioterapeuta.Read();

			Assert.AreEqual(IdFisioterapeuta, fisios[fisios.Count - 1].idFisioterapeuta);
			Assert.AreEqual(expectedscene, currentscene);
		}

		[UnityTest]
		public static IEnumerator TestSaveExercise()
		{
			Flow.StaticLogin();

			yield return new WaitForSeconds(0.5f);

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

			yield return new WaitForSeconds(0.5f);

			createExercise.CreateExercise();
			var device = @"^(.*?(\bDevice|SDK\b)[^$]*)$";
			Regex rgx1 = new Regex(device, RegexOptions.IgnoreCase);
			LogAssert.Expect(LogType.Error, rgx1);

			yield return new WaitForSeconds(0.5f);

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "RealtimeGraphKinectPatient";

			var exer = Exercicio.Read();

			Assert.AreEqual(currentscene, expectedscene);
			Assert.AreEqual(GlobalController.instance.exercise.idExercicio, exer[exer.Count - 1].idExercicio);
		}

		[UnityTest]
		public static IEnumerator TestSaveSession()
		{
			Flow.StaticLogin();

			yield return new WaitForSeconds(0.5f);

			Pessoa.Insert("patient name1", "m", "1995-01-01", "6198732711", null);
			Pessoa.Insert("physio name1", "m", "1995-01-03", "6198732713", null);
			Fisioterapeuta.Insert(2, "abracadabra1", "demais1", null, null);
			Paciente.Insert(1, null);

			var pacient = Paciente.Read();
			var fisio = Fisioterapeuta.Read();

			GlobalController.instance.user = pacient[pacient.Count - 1];
			GlobalController.instance.admin = fisio[fisio.Count - 1];

			Flow.StaticSessions();

			yield return new WaitForSeconds(0.5f);

			createSession.CreateSessao();

			yield return new WaitForSeconds(0.5f);

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "NewSession";

			var sess = Sessao.Read();

			Assert.AreEqual(currentscene, expectedscene);
			Assert.AreEqual(GlobalController.instance.session.idSessao, sess[sess.Count - 1].idSessao);
		}


		[UnityTest]
		public static IEnumerator TestSaveMovement()
		{
			Flow.StaticLogin();

			yield return new WaitForSeconds(1f);

			Pessoa.Insert("physio name1", "m", "1995-01-01", "6198732711", null);
			Fisioterapeuta.Insert(1, "abracadabra1", "demais1", null, null);

			var fisio = Fisioterapeuta.Read();

			GlobalController.instance.admin = fisio[fisio.Count - 1];

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

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "RealtimeGraphKinectPhysio";

			var move = Movimento.Read();

			Assert.AreEqual(currentscene, expectedscene);
			Assert.AreEqual(GlobalController.instance.movement.idMovimento, move[move.Count - 1].idMovimento);
		}

		[UnityTest]
		public static IEnumerator TestSavePatient()
		{
			Flow.StaticLogin();
			Flow.StaticNewPatient();

			yield return null;
			
			var objectPatient = GameObject.Find("PatientManager");
			var PatientManager = objectPatient.GetComponentInChildren<createPatient>();

			InputField aux = (InputField)PatientManager.GetMemberValue("namePatient");
			aux.text = "Fake Name";
			PatientManager.SetMemberValue("namePatient", aux);

			InputField aux1 = (InputField)PatientManager.GetMemberValue("date");
			aux1.text = "01/01/1920";
			PatientManager.SetMemberValue("date", aux1);
			
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

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "NewPatient";

			var patients = Paciente.Read();

			Assert.AreEqual(IdPaciente, patients[patients.Count - 1].idPaciente);
			Assert.AreEqual(expectedscene, currentscene);
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
