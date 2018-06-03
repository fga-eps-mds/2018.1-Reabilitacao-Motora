using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using System;


namespace Tests
{
	public static class TestFlow
	{
		[SetUp]
		public static void SetUp()
		{
			GlobalController.test = true;
			GlobalController.Initialize();
		}

		[UnityTest]
		public static IEnumerator TestNewMovement()
		{
			Flow.StaticNewMovement();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "NewMovement";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log("saindo de " + currentscene);
		}

		[UnityTest]
		public static IEnumerator TestPatient()
		{
			Flow.StaticPatient();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Patient";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log("saindo de " + currentscene);
		}

		[UnityTest]
		public static IEnumerator _TestLogin()
		{
			Flow.StaticLogin();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Login";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log("saindo de " + currentscene);
		}

		[UnityTest]
		public static IEnumerator _TestMovements()
		{
			Flow.StaticMovements();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Movements";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log("saindo de " + currentscene);
		}

		[UnityTest]
		public static IEnumerator TestNewPatient()
		{
			Flow.StaticNewPatient();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "NewPatient";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log("saindo de " + currentscene);
		}

		[UnityTest]
		public static IEnumerator TestUpdatePatient()
		{
			Flow.StaticUpdatePatient();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "UpdatePatient";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log("saindo de " + currentscene);
		}


		[UnityTest]
		public static IEnumerator TestRealtimeGraphUDPPatient()
		{
			Flow.StaticRealtimeGraphUDPPatient();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "RealtimeGraphUDPPatient";

			var device = @"^(.*?(\bDevice|Socket|SDK\b)[^$]*)$";
			Regex rgx1 = new Regex(device, RegexOptions.IgnoreCase);
			LogAssert.Expect(LogType.Error, rgx1);
			LogAssert.Expect(LogType.Exception, rgx1);

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log("saindo de " + currentscene);
		}

		[UnityTest]
		public static IEnumerator TestRealtimeGraphKinectPatient()
		{
			Flow.StaticRealtimeGraphKinectPatient();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "RealtimeGraphKinectPatient";

			var device = @"^(.*?(\bDevice|SDK\b)[^$]*)$";
			Regex rgx1 = new Regex(device, RegexOptions.IgnoreCase);
			LogAssert.Expect(LogType.Error, rgx1);

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log("saindo de " + currentscene);
		}

		[UnityTest]
		public static IEnumerator TestRealtimeGraphUDPPhysio()
		{
			Flow.StaticRealtimeGraphUDPPhysio();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "RealtimeGraphUDPPhysio";

			var device = @"^(.*?(\bDevice|Socket|SDK\b)[^$]*)$";
			Regex rgx1 = new Regex(device, RegexOptions.IgnoreCase);
			LogAssert.Expect(LogType.Error, rgx1);
			LogAssert.Expect(LogType.Exception, rgx1);

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log("saindo de " + currentscene);
		}

		[UnityTest]
		public static IEnumerator TestRealtimeGraphKinectPhysio()
		{
			Flow.StaticRealtimeGraphKinectPhysio();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "RealtimeGraphKinectPhysio";

			var device = @"^(.*?(\bDevice|SDK\b)[^$]*)$";
			Regex rgx1 = new Regex(device, RegexOptions.IgnoreCase);
			LogAssert.Expect(LogType.Error, rgx1);

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log("saindo de " + currentscene);
		}




		[UnityTest]
		public static IEnumerator TestNewPhysiotherapist()
		{
			Flow.StaticNewPhysiotherapist();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "NewPhysiotherapist";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log("saindo de " + currentscene);
		}

		[UnityTest]
		public static IEnumerator TestMenu()
		{
			Flow.StaticMenu();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Menu";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log("saindo de " + currentscene);
		}

		[UnityTest]
		public static IEnumerator TestGraphs2()
		{
			Flow.StaticGraphs2();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Graphs2";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log("saindo de " + currentscene);
		}

		[UnityTest]
		public static IEnumerator TestNotImplemented()
		{
			Flow.StaticNotImplemented();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "NotImplemented";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log("saindo de " + currentscene);
		}

		[UnityTest]
		public static IEnumerator TestSessions()
		{
			Flow.StaticSessions();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Sessions";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log("saindo de " + currentscene);
		}

		[UnityTest]
		public static IEnumerator TestSession()
		{
			Flow.StaticSession();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Session";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log("saindo de " + currentscene);
		}

		[UnityTest]
		public static IEnumerator TestNewSession()
		{
			Flow.StaticNewSession();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "NewSession";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log("saindo de " + currentscene);
		}

		[UnityTest]
		public static IEnumerator TestMovementsToExercise()
		{
			Flow.StaticMovementsToExercise();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "MovementsToExercise";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log("saindo de " + currentscene);
		}

		[UnityTest]
		public static IEnumerator TestCharacterMenu()
		{
			Flow.StaticCharacterMenu();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "CharacterMenu";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log("saindo de " + currentscene);
		}

	}
}
