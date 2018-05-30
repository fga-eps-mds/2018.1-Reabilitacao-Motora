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
 * Esta classe testa os métodos referentes aos Movimentos.
 */
namespace Tests
{
	public static class TestCreateMovement
	{
		[SetUp]
		public static void SetUp()
		{
			GlobalController.test = true;
			GlobalController.Initialize();
		}

		[Test]
		public static void TestValidInput()
		{
			var test_nomeMovimento = new GameObject();
			var test_musculos = new GameObject();

			InputField nomeMovimento =  test_nomeMovimento.AddComponent<InputField>() as InputField;
			InputField musculos = test_musculos.AddComponent<InputField>() as InputField;

			List<InputField> inputs = new List<InputField>();

			nomeMovimento.text = "Movimentação do Braço Esquerdo";
			musculos.text = "Deltóide";

			inputs.Add(nomeMovimento);
			inputs.Add(musculos);

			bool response = createMovement.ValidInput(inputs);

			Assert.AreEqual(response, false);
		}

		[Test]
		public static void TestApplyColor ()
		{
			var test_colorExpected = new GameObject();
			var test_colorResponse = new GameObject();

			var inputExpected = test_colorExpected.AddComponent<InputField>() as InputField;
			var inputResponse = test_colorResponse.AddComponent<InputField>() as InputField;

			inputExpected.colors = ColorManager.SetColor(inputExpected.colors, true);

			createMovement.ApplyColor(inputResponse, true);

			Assert.AreEqual(inputExpected.colors, inputResponse.colors);
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
		}
	}
}
