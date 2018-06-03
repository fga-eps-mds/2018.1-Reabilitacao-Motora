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