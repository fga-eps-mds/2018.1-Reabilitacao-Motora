using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class TestFlow
    {
        [UnityTest]
        public static IEnumerator TestCreateMove()
        {
            var createmove = new GameObject().AddComponent<Flow>();
            createmove.CreateMove();

            yield return null;

            var currentscene = SceneManager.GetActiveScene().name;
            var expectedscene = "NewMovement";

            Assert.AreEqual(currentscene, expectedscene);
        }

        [UnityTest]
        public static IEnumerator TestRecordMove()
        {
            var recordmove = new GameObject().AddComponent<Flow>();
            recordmove.RecordMove();

            yield return null;

            var currentscene = SceneManager.GetActiveScene().name;
            var expectedscene = "Clinic";

            Assert.AreEqual(currentscene, expectedscene);
        }

        [UnityTest]
        public static IEnumerator TestPatient()
        {
            var patient = new GameObject().AddComponent<Flow>();
            patient.Patient();

            yield return null;

            var currentscene = SceneManager.GetActiveScene().name;
            var expectedscene = "Patient";

            Assert.AreEqual(currentscene, expectedscene);
        }

        [UnityTest]
        public static IEnumerator TestPatients()
        {
            var patients = new GameObject().AddComponent<Flow>();
            patients.Patients();

            yield return null;

            var currentscene = SceneManager.GetActiveScene().name;
            var expectedscene = "Patients";

            Assert.AreEqual(currentscene, expectedscene);
        }

        [UnityTest]
        public static IEnumerator _TestLogin()
        {
            var login = new GameObject().AddComponent<Flow>();
            login.Login();

            yield return null;

            var currentscene = SceneManager.GetActiveScene().name;
            var expectedscene = "Login";

            Assert.AreEqual(currentscene, expectedscene);
        }

        [UnityTest]
        public static IEnumerator _TestMovements()
        {
            var movements = new GameObject().AddComponent<Flow>();
            movements.Movements();

            yield return null;

            var currentscene = SceneManager.GetActiveScene().name;
            var expectedscene = "Movements";

            Assert.AreEqual(currentscene, expectedscene);
        }

        [UnityTest]
        public static IEnumerator TestNewPatient()
        {
            var newpatient = new GameObject().AddComponent<Flow>();
            newpatient.NewPatient();

            yield return null;

            var currentscene = SceneManager.GetActiveScene().name;
            var expectedscene = "NewPatient";

            Assert.AreEqual(currentscene, expectedscene);
        }

        [UnityTest]
        public static IEnumerator TestUpdatePatient()
        {
            var updatepatient = new GameObject().AddComponent<Flow>();
            updatepatient.UpdatePatient();

            yield return null;

            var currentscene = SceneManager.GetActiveScene().name;
            var expectedscene = "UpdatePatient";

            Assert.AreEqual(currentscene, expectedscene);
        }

        [UnityTest]
        public static IEnumerator TestSuccessRegister()
        {
            var createmove = new GameObject().AddComponent<Flow>();
            createmove.SuccessRegister();

            yield return null;

            var currentscene = SceneManager.GetActiveScene().name;
            var expectedscene = "SuccessRegister";

            Assert.AreEqual(currentscene, expectedscene);
        }

        [UnityTest]
        public static IEnumerator TestRealtimeGraphs()
        {
            var createmove = new GameObject().AddComponent<Flow>();
            createmove.RealTimeGraphs();

            yield return null;

            var currentscene = SceneManager.GetActiveScene().name;
            var expectedscene = "RealtimeGraph";

            Assert.AreEqual(currentscene, expectedscene);     
        }

        [UnityTest]
        public static IEnumerator TestNewPhysiotherapist()
        {
            var createmove = new GameObject().AddComponent<Flow>();
            createmove.NewPhysiotherapist();

            yield return null;

            var currentscene = SceneManager.GetActiveScene().name;
            var expectedscene = "NewPhysiotherapist";

            Assert.AreEqual(currentscene, expectedscene);
        }

        [UnityTest]
        public static IEnumerator TestBackToHomeMenu()
        {
            var createmove = new GameObject().AddComponent<Flow>();
            createmove.BackToHomeMenu();

            yield return null;

            var currentscene = SceneManager.GetActiveScene().name;
            var expectedscene = "Login";

            Assert.AreEqual(currentscene, expectedscene);
        }

        [UnityTest]
        public static IEnumerator TestBackToMenu()
        {
            var createmove = new GameObject().AddComponent<Flow>();
            createmove.BackToMenu();

            yield return null;

            var currentscene = SceneManager.GetActiveScene().name;
            var expectedscene = "Menu";

            Assert.AreEqual(currentscene, expectedscene);
        }

        [UnityTest]
        public static IEnumerator TestGraphs()
        {
            var createmove = new GameObject().AddComponent<Flow>();
            createmove.Graphs();

            yield return null;

            var currentscene = SceneManager.GetActiveScene().name;
            var expectedscene = "Graphs2";

            Assert.AreEqual(currentscene, expectedscene);
        }

        [UnityTest]
        public static IEnumerator TestNotImplemented()
        {
            var createmove = new GameObject().AddComponent<Flow>();
            createmove.NotImplemented();

            yield return null;

            var currentscene = SceneManager.GetActiveScene().name;
            var expectedscene = "NotImplemented";

            Assert.AreEqual(currentscene, expectedscene);
        }

        [UnityTest]
        public static IEnumerator TestSessions()
        {
            var createmove = new GameObject().AddComponent<Flow>();
            createmove.Sessions();

            yield return null;

            var currentscene = SceneManager.GetActiveScene().name;
            var expectedscene = "Sessions";

            Assert.AreEqual(currentscene, expectedscene);
        }

        [UnityTest]
        public static IEnumerator TestSession()
        {
            var createmove = new GameObject().AddComponent<Flow>();
            createmove.Session();

            yield return null;

            var currentscene = SceneManager.GetActiveScene().name;
            var expectedscene = "Session";

            Assert.AreEqual(currentscene, expectedscene);
        }
    }
}