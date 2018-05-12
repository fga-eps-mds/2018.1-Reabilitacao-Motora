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
		public static IEnumerator TestNewMovement()
		{
			Debug.Log("___________ NewMovement __________");
			Flow.StaticNewMovement();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "NewMovement";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log(string.Format("Saindo de {0}", expectedscene));
			Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-");
		}

		[UnityTest]
		public static IEnumerator TestClinic()
		{
			Debug.Log("___________ Clinic __________");
			Flow.StaticClinic();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Clinic";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log(string.Format("Saindo de {0}", expectedscene));
			Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-");
		}

		[UnityTest]
		public static IEnumerator TestPatient()
		{
			Debug.Log("___________ Patient __________");
			Flow.StaticPatient();
			
			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Patient";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log(string.Format("Saindo de {0}", expectedscene));
			Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-");
		}

		[UnityTest]
		public static IEnumerator _TestLogin()
		{
			Debug.Log("___________ Login __________");
			Flow.StaticLogin();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Login";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log(string.Format("Saindo de {0}", expectedscene));
			Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-");
		}

		[UnityTest]
		public static IEnumerator _TestMovements()
		{
			Debug.Log("___________ Movements __________");
			Flow.StaticMovements();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Movements";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log(string.Format("Saindo de {0}", expectedscene));
			Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-");
		}

		[UnityTest]
		public static IEnumerator TestNewPatient()
		{
			Debug.Log("___________ NewPatient __________");
			Flow.StaticNewPatient();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "NewPatient";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log(string.Format("Saindo de {0}", expectedscene));
			Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-");
		}

		[UnityTest]
		public static IEnumerator TestUpdatePatient()
		{
			Debug.Log("___________ UpdatePatient __________");
			Flow.StaticUpdatePatient();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "UpdatePatient";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log(string.Format("Saindo de {0}", expectedscene));
			Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-");
		}


		[UnityTest]
		public static IEnumerator TestRealtimeGraph()
		{
			Debug.Log("___________ RealtimeGraph __________");
			Flow.StaticRealtimeGraph();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "RealtimeGraph";

			Assert.AreEqual(currentscene, expectedscene);     
			Debug.Log(string.Format("Saindo de {0}", expectedscene));
			Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-");
		}

		[UnityTest]
		public static IEnumerator TestNewPhysiotherapist()
		{
			Debug.Log("___________ NewPhysiotherapist __________");
			Flow.StaticNewPhysiotherapist();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "NewPhysiotherapist";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log(string.Format("Saindo de {0}", expectedscene));
			Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-");
		}

		[UnityTest]
		public static IEnumerator TestMenu()
		{
			Debug.Log("___________ Menu __________");
			Flow.StaticMenu();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Menu";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log(string.Format("Saindo de {0}", expectedscene));
			Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-");
		}

		[UnityTest]
		public static IEnumerator TestGraphs2()
		{
			Debug.Log("___________ Graphs2 __________");
			Flow.StaticGraphs2();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Graphs2";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log(string.Format("Saindo de {0}", expectedscene));
			Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-");
		}

		[UnityTest]
		public static IEnumerator TestNotImplemented()
		{
			Debug.Log("___________ NotImplemented __________");
			Flow.StaticNotImplemented();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "NotImplemented";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log(string.Format("Saindo de {0}", expectedscene));
			Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-");
		}

		[UnityTest]
		public static IEnumerator TestSessions()
		{
			Debug.Log("___________ Sessions __________");
			Flow.StaticSessions();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Sessions";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log(string.Format("Saindo de {0}", expectedscene));
			Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-");
		}

		[UnityTest]
		public static IEnumerator TestSession()
		{
			Debug.Log("___________ Session __________");
			Flow.StaticSession();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "Session";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log(string.Format("Saindo de {0}", expectedscene));
			Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-");
		}

		[UnityTest]
		public static IEnumerator TestNewSession()
		{
			Debug.Log("___________ NewSession __________");
			Flow.StaticNewSession();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "NewSession";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log(string.Format("Saindo de {0}", expectedscene));
			Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-");
		}

		[UnityTest]
		public static IEnumerator TestMovementsToExercise()
		{
			Debug.Log("___________ MovementsToExercise __________");
			Flow.StaticMovementsToExercise();

			yield return null;

			var currentscene = SceneManager.GetActiveScene().name;
			var expectedscene = "MovementsToExercise";

			Assert.AreEqual(currentscene, expectedscene);
			Debug.Log(string.Format("Saindo de {0}", expectedscene));
			Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-");
		}
	}
}