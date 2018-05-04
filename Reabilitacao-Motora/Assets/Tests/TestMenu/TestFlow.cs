using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Tests
{
	public static class TestFlow
	{
		[UnityTest]
		public static IEnumerator TestCreateMove()
		{
			Flow.StaticCreateMove();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "NewMovement";

			Assert.AreEqual(currentscene, expectedscene);
		}

		[UnityTest]
		public static IEnumerator TestRecordMove()
		{
			Flow.StaticRecordMove();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Clinic";

			Assert.AreEqual(currentscene, expectedscene);
		}

		[UnityTest]
		public static IEnumerator TestPatient()
		{
			Flow.StaticPatient();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Patient";

			Assert.AreEqual(currentscene, expectedscene);
		}

		[UnityTest]
		public static IEnumerator TestPatients()
		{
			Flow.StaticPatients();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Patients";

			Assert.AreEqual(currentscene, expectedscene);
		}

		[UnityTest]
		public static IEnumerator _TestLogin()
		{
			Flow.StaticLogin();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Login";

			Assert.AreEqual(currentscene, expectedscene);
		}

		[UnityTest]
		public static IEnumerator _TestMovements()
		{
			Flow.StaticMovements();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Movements";

			Assert.AreEqual(currentscene, expectedscene);
		}

		[UnityTest]
		public static IEnumerator TestNewPatient()
		{
			Flow.StaticNewPatient();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "NewPatient";

			Assert.AreEqual(currentscene, expectedscene);
		}

		[UnityTest]
		public static IEnumerator TestUpdatePatient()
		{
			Flow.StaticUpdatePatient();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "UpdatePatient";

			Assert.AreEqual(currentscene, expectedscene);
		}

		[UnityTest]
		public static IEnumerator TestSuccessRegister()
		{
			Flow.StaticSuccessRegister();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "SuccessRegister";

			Assert.AreEqual(currentscene, expectedscene);
		}

		[UnityTest]
		public static IEnumerator TestRealtimeGraphs()
		{
			Flow.StaticRealTimeGraphs();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "RealtimeGraph";

			Assert.AreEqual(currentscene, expectedscene);     
		}

		[UnityTest]
		public static IEnumerator TestNewPhysiotherapist()
		{
			Flow.StaticNewPhysiotherapist();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "NewPhysiotherapist";

			Assert.AreEqual(currentscene, expectedscene);
		}

		[UnityTest]
		public static IEnumerator TestBackToHomeMenu()
		{
			Flow.StaticBackToHomeMenu();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Login";

			Assert.AreEqual(currentscene, expectedscene);
		}

		[UnityTest]
		public static IEnumerator TestBackToMenu()
		{
			Flow.StaticBackToMenu();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Menu";

			Assert.AreEqual(currentscene, expectedscene);
		}

		[UnityTest]
		public static IEnumerator TestGraphs()
		{
			Flow.StaticGraphs();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Graphs2";

			Assert.AreEqual(currentscene, expectedscene);
		}

		[UnityTest]
		public static IEnumerator TestNotImplemented()
		{
			Flow.StaticNotImplemented();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "NotImplemented";

			Assert.AreEqual(currentscene, expectedscene);
		}

		[UnityTest]
		public static IEnumerator TestSessions()
		{
			Flow.StaticSessions();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Sessions";

			Assert.AreEqual(currentscene, expectedscene);
		}

		[UnityTest]
		public static IEnumerator TestSession()
		{
			Flow.StaticSession();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Session";

			Assert.AreEqual(currentscene, expectedscene);
		}
	}
}