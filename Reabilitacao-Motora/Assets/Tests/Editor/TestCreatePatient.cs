using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using NUnit.Framework;
using paciente;
using pessoa;
using Mono.Data.Sqlite;
using System.Data;


/**
 * Esta classe testa os métodos referentes a paciente.
 */
namespace Tests
{
	public static class TestCreatePatient
	{
		[SetUp]
		public static void SetUp()
		{
			GlobalController.test = true;           
			GlobalController.Initialize();
		}
		
		/** 
		 * Este método testa a função de mudar a cor de um inputfield.
		 */
		[Test]
		public static void TestApplyColor ()
		{
			GameObject gameobject1 = new GameObject ();
			var inputExpected = gameobject1.AddComponent<InputField>() as InputField;

			GameObject gameobject2 = new GameObject ();
			var inputResponse = gameobject2.AddComponent<InputField>() as InputField;

			inputExpected.colors = ColorManager.SetColor(inputExpected.colors, true);

			createPatient.ApplyColor(inputResponse, true);
			
			Assert.AreEqual(inputExpected.colors, inputResponse.colors);
		}

		[Test]
		public static void TestValidInput ()
		{

			GameObject gameobject1 = new GameObject ();
			var name = gameobject1.AddComponent<InputField>() as InputField;

			GameObject gameobject2 = new GameObject ();
			var date = gameobject2.AddComponent<InputField>() as InputField;

			GameObject gameobject3 = new GameObject ();
			var phone1 = gameobject3.AddComponent<InputField>() as InputField;

			GameObject gameobject4 = new GameObject ();
			var masc = gameobject4.AddComponent<Toggle>() as Toggle;

			GameObject gameobject5 = new GameObject ();
			var fem = gameobject5.AddComponent<Toggle>() as Toggle;

			GameObject gameobject6 = new GameObject ();
			var phone2 = gameobject6.AddComponent<InputField>() as InputField;

			List<InputField> inputs = new List<InputField>();
			List<Toggle> toggles = new List<Toggle>();

			masc.isOn = true;
			name.text = "Izabella Ribeiro";
			date.text = "15/10/1998";
			phone1.text = "61992960111";
			phone2.text = "61984105449";

			inputs.Add(name);
			inputs.Add(date);
			inputs.Add(phone1);
			inputs.Add(phone2);
			toggles.Add(masc);
			toggles.Add(fem);

			bool response = createPatient.ValidInput(inputs, toggles);

			Assert.AreEqual(response, true);
		}

		/* 
		[Test]
		public static void TestSavePatient ()
		{	
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

			InputField aux7 = (InputField)PatientManager.GetMemberValue("notes");
			aux7.text = "fake notes lorem ipsum";
			PatientManager.SetMemberValue("notes", aux7);

			Toggle aux2 = (Toggle)PatientManager.GetMemberValue("male");
			aux2.isOn = true;
			PatientManager.SetMemberValue("male", aux2);

			Toggle aux0 = (Toggle)PatientManager.GetMemberValue("female");
			aux0.isOn = false;
			PatientManager.SetMemberValue("female", aux0);

			PatientManager.savePatient();

			int IdPaciente = GlobalController.instance.user.idPaciente;
			int IdPessoa = GlobalController.instance.user.persona.idPessoa;		

			List<Paciente> allPatients = Paciente.Read();

			for (int i = 0; i < allPatients.Count; ++i)
			{
				if(allPatients[i].persona.idPessoa == IdPessoa) {
					Assert.AreEqual (allPatients[i].observacoes, "fake notes lorem ipsum");
				}
			}

		}
		*/

		[UnityTest]
		public static IEnumerator TestSaveButton()
		{
			Flow.StaticNewPatient();

			yield return null;
			
			var objectPatient = GameObject.Find("PatientManager");
			var PatientManager = objectPatient.GetComponentInChildren<createPatient>();

			var objectButton = GameObject.Find("Canvas/PanelPatient/SaveBt");
			var button = objectButton.GetComponentInChildren<Button>();

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

			button.OnPointerClick(new PointerEventData(EventSystem.current));

			int IdPaciente = GlobalController.instance.user.idPaciente;
			int IdPessoa = GlobalController.instance.user.persona.idPessoa;
			Paciente.DeleteValue(IdPaciente);
			Pessoa.DeleteValue(IdPessoa);

			yield return new WaitForSeconds(0.5f);

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "newPatient";

			Assert.AreEqual(expectedscene, currentscene);
		}
		

		[TearDown]
		public static void AfterEveryTest ()
		{
			SqliteConnection.ClearAllPools();
			GlobalController.DropAll();

			foreach (var go in UnityEngine.Object.FindObjectsOfType<InputField>())
			{
				UnityEngine.Object.DestroyImmediate(go.gameObject);
			}

			foreach (var go in UnityEngine.Object.FindObjectsOfType<Toggle>())
			{
				UnityEngine.Object.DestroyImmediate(go.gameObject);
			}
		}
	}
}