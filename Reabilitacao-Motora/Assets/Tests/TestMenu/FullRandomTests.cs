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
	public static class FullRandomTests
	{
		public static void LoginEnter()
		{
			LoginCancelarSair();
			var button = GameObject.Find("/Canvas/Panel/LoginBt").GetComponent<Button>();

			var input1 = GameObject.Find("/Canvas/Panel/InputFieldLogin").GetComponentInChildren<InputField>();
			input1.text = "seloco";
			var input2 = GameObject.Find("/Canvas/Panel/InputFieldPassword").GetComponentInChildren<InputField>();
			input2.text = "rapaziada";

			button.OnPointerClick(new PointerEventData(EventSystem.current));
		}

		public static void LoginCadastrar()
		{
			LoginCancelarSair();
			var button = GameObject.Find("/Canvas/Panel/RegisterBt").GetComponent<Button>();
			button.OnPointerClick(new PointerEventData(EventSystem.current));
		}

		public static void LoginSair()
		{
			LoginCancelarSair();
			var button = GameObject.Find("/Canvas/Quit").GetComponent<Button>();
			button.OnPointerClick(new PointerEventData(EventSystem.current));
		}

		public static void LoginCancelarSair()
		{
			bool active = GameObject.Find("/Canvas/PanelDelete/CancelBt");
			if (active)
			{
				var button = GameObject.Find("/Canvas/PanelDelete/CancelBt").GetComponent<Button>();
				button.OnPointerClick(new PointerEventData(EventSystem.current));
			}
		}

		public static void NewPhysiotherapistVoltar()
		{
			NewPhysiotherapistOkPopUp();
			var button = GameObject.Find("/Canvas/BackBt").GetComponent<Button>();
			button.OnPointerClick(new PointerEventData(EventSystem.current));
		}

		public static void NewPhysiotherapistSalvar()
		{
			NewPhysiotherapistOkPopUp();
			bool notregistered = true;
			var fisios = Fisioterapeuta.Read();
			foreach(var fisio in fisios)
			{
				if (fisio.login == "seloco")
				{
					notregistered = false;
				}
			}

			var button = GameObject.Find("/Canvas/PanelPhysiotherapist/SaveBt").GetComponent<Button>();

			if (notregistered)
			{

				var input1 = GameObject.Find("/Canvas/PanelPhysiotherapist/InputFieldName").GetComponentInChildren<InputField>();
				input1.text = "Joao Carioca";
				var toggle = GameObject.Find("/Canvas/PanelPhysiotherapist/ToggleMale").GetComponentInChildren<Toggle>();
				toggle.isOn = true;
				var input2 = GameObject.Find("/Canvas/PanelPhysiotherapist/InputFieldDateOfBirth").GetComponentInChildren<InputField>();
				input2.text = "10/10/1990";
				var input3 = GameObject.Find("/Canvas/PanelPhysiotherapist/InputFieldPhone1").GetComponentInChildren<InputField>();
				input3.text = "6196825656";
				var input4 = GameObject.Find("/Canvas/PanelPhysiotherapist/InputFieldLogin").GetComponentInChildren<InputField>();
				input4.text = "seloco";
				var input5 = GameObject.Find("/Canvas/PanelPhysiotherapist/InputFieldPassword").GetComponentInChildren<InputField>();
				input5.text = "rapaziada";
				var input6 = GameObject.Find("/Canvas/PanelPhysiotherapist/InputFieldConfirmPassword").GetComponentInChildren<InputField>();
				input6.text = "rapaziada";
			}
			
			button.OnPointerClick(new PointerEventData(EventSystem.current));
		}

		public static void NewPhysiotherapistCancelar()
		{
			NewPhysiotherapistOkPopUp();
			var button = GameObject.Find("/Canvas/PanelPhysiotherapist/CancelBt").GetComponent<Button>();
			button.OnPointerClick(new PointerEventData(EventSystem.current));
		}

		public static void NewPhysiotherapistAjuda()
		{
			NewPhysiotherapistOkPopUp();
			var button = GameObject.Find("/Canvas/Help").GetComponent<Button>();
			button.OnPointerClick(new PointerEventData(EventSystem.current));
		}
		
		public static void NewPhysiotherapistOkPopUp()
		{
			bool active = GameObject.Find("/Canvas/PanelValidation/OkBt");
			if (active)
			{
				var button = GameObject.Find("/Canvas/PanelValidation/OkBt").GetComponent<Button>();
				button.OnPointerClick(new PointerEventData(EventSystem.current));
			}
		}

		public static void MenuPaciente()
		{
			var button = GameObject.Find("/Canvas/PacientsBt").GetComponent<Button>();
			button.OnPointerClick(new PointerEventData(EventSystem.current));
		}

		public static void MenuMovimentos()
		{
			var button = GameObject.Find("/Canvas/MovesBt").GetComponent<Button>();
			button.OnPointerClick(new PointerEventData(EventSystem.current));
		}

		public static void MenuAjuda()
		{
			var button = GameObject.Find("/Canvas/HelpBt").GetComponent<Button>();
			button.OnPointerClick(new PointerEventData(EventSystem.current));
		}

		public static void MenuSair()
		{
			var button = GameObject.Find("/Canvas/ExitBt").GetComponent<Button>();
			button.OnPointerClick(new PointerEventData(EventSystem.current));
		}
		
		public static void MovementsVoltar()
		{
			MovementsCancelarDeletarMovimento();
			var button = GameObject.Find("/Canvas/BackBt").GetComponent<Button>();
			button.OnPointerClick(new PointerEventData(EventSystem.current));
		}

		public static void MovementsVisualizarMovimento()
		{
			MovementsCancelarDeletarMovimento();
			var button = GameObject.Find("/Canvas/MovimentoMovements(Clone)/movimento").GetComponent<Button>();
			button.OnPointerClick(new PointerEventData(EventSystem.current));
		}

		public static void MovementsDeletarMovimento()
		{
			MovementsCancelarDeletarMovimento();
			var button = GameObject.Find("/Canvas/MovimentoMovements(Clone)/DeleteBt").GetComponent<Button>();
			button.OnPointerClick(new PointerEventData(EventSystem.current));
		}

		public static void MovementsCancelarDeletarMovimento()
		{
			bool active = GameObject.Find("/Canvas/PanelDelete/CancelBt");
			if (active)
			{
				var button = GameObject.Find("/Canvas/PanelDelete/CancelBt").GetComponent<Button>();
				button.OnPointerClick(new PointerEventData(EventSystem.current));
			}
		}

		public static void MovementsConfirmarDeletarMovimento()
		{
			bool active = GameObject.Find("/Canvas/PanelDelete/DeleteBt");
			if (active)
			{
				var button = GameObject.Find("/Canvas/PanelDelete/DeleteBt").GetComponent<Button>();
				button.OnPointerClick(new PointerEventData(EventSystem.current));
			}
		}

		public static void MovementsGravarMovimento()
		{
			MovementsCancelarDeletarMovimento();
			var button = GameObject.Find("/Canvas/Gravar Movimento").GetComponent<Button>();
			button.OnPointerClick(new PointerEventData(EventSystem.current));
		}
		
		public static void NewMovementVoltar()
		{

		}
		public static void NewMovementSalvar()
		{

		}
		public static void NewMovementCancelar()
		{

		}
		
		public static void ChoiceSensorVoltar()
		{

		}
		public static void ChoiceSensorEscolherSensor()
		{

		}

		public static void RealtimeGraphKinectPatientvoltar()
		{

		}
		public static void RealtimeGraphKinectPatientrotular()
		{

		}
		public static void RealtimeGraphKinectPatientdeletarRotulo()
		{

		}
		public static void RealtimeGraphKinectPatientComecarAGravar()
		{

		}

		public static void RealtimeGraphKinectPhysiovoltar()
		{

		}
		public static void RealtimeGraphKinectPhysiorotular()
		{

		}
		public static void RealtimeGraphKinectPhysiodeletarRotulo()
		{

		}
		public static void RealtimeGraphKinectPhysioComecarAGravar()
		{

		}

		public static void RealtimeGraphUDPPatientvoltar()
		{

		}
		public static void RealtimeGraphUDPPatientrotular()
		{

		}
		public static void RealtimeGraphUDPPatientdeletarRotulo()
		{

		}
		public static void RealtimeGraphUDPPatientComecarAGravar()
		{

		}

		public static void RealtimeGraphUDPPhysiovoltar()
		{

		}
		public static void RealtimeGraphUDPPhysiorotular()
		{

		}
		public static void RealtimeGraphUDPPhysiodeletarRotulo()
		{

		}
		public static void RealtimeGraphUDPPhysioComecarAGravar()
		{

		}

		public static void NewPatientVoltar()
		{

		}
		public static void NewPatientSalvar()
		{

		}
		public static void NewPatientCancelar()
		{

		}
		public static void NewPatientVisualizarPaciente()
		{

		}
		public static void NewPatientDeletarPaciente()
		{

		}

		public static void PatientVoltar()
		{

		}
		public static void PatientCancelar()
		{

		}
		public static void PatientEditar()
		{

		}
		public static void PatientSessoes()
		{

		}

		public static void UpdatePatientSalvar()
		{

		}
		public static void UpdatePatientVoltar()
		{

		}

		public static void SessionsVoltar()
		{

		}
		public static void SessionsVisualizarSessao()
		{

		}
		public static void SessionsDeletarSessao()
		{

		}
		public static void SessionsNovaSessao()
		{

		}

		public static void NewSessionFinalizarSessao()
		{

		}
		public static void NewSessionAdicionarObservacao()
		{

		}
		public static void NewSessionCadastrarNovoExercicio()
		{

		}
		public static void NewSessionVoltar()
		{

		}

		public static void MovementsToReproduceVoltar()
		{

		}
		public static void MovementsToReproduceEscolher()
		{

		}

		public static void EndSessionSalvar()
		{

		}
		public static void EndSessionVoltar()
		{

		}

		public static void SessionVerExercicios()
		{

		}
		public static void SessionVoltar()
		{

		}

		public static void MovementsToReviewVoltar()
		{

		}
		public static void MovementsToReviewEscolher()
		{

		}

		public static void ExercisesToReviewVoltar()
		{

		}
		public static void ExercisesToReviewVisualizar()
		{

		}
		public static void ExercisesToReviewDeletar()
		{

		}


		[UnityTest]
		public static IEnumerator TestDeleteMovement()
		{
			GlobalController.test = true;

			var scenes = new Dictionary<string, Action[]>();
			scenes["Login"] = new Action[] {()=> LoginEnter(), ()=> LoginCadastrar(), ()=> LoginSair(), ()=> LoginCancelarSair()};
			scenes["NewPhysiotherapist"] = new Action[] {()=> NewPhysiotherapistCancelar(), ()=> NewPhysiotherapistSalvar(), ()=> NewPhysiotherapistVoltar(), ()=> NewPhysiotherapistAjuda(), ()=> NewPhysiotherapistOkPopUp()};
			scenes["Menu"] = new Action[] {()=> MenuSair(), ()=> MenuAjuda(), ()=> MenuMovimentos(), ()=> MenuPaciente()};
			scenes["Movements"] = new Action[] {()=> MovementsVoltar(), ()=> MovementsGravarMovimento(), ()=> MovementsDeletarMovimento(), ()=> MovementsVisualizarMovimento(), ()=> MovementsCancelarDeletarMovimento(), ()=> MovementsConfirmarDeletarMovimento()};
			// scenes["NewMovement"] = new Action[] {()=> NewMovementCancelar(), ()=> NewMovementSalvar(), ()=> NewMovementVoltar()};
			// scenes["ChoiceSensor"] = new Action[] {()=> ChoiceSensorVoltar(), ()=> ChoiceSensorEscolherSensor()};
			// scenes["RealtimeGraphKinectPatient"] = new Action[] {()=> RealtimeGraphKinectPatientrotular(), ()=> RealtimeGraphKinectPatientvoltar(), ()=> RealtimeGraphKinectPatientdeletarRotulo(), ()=> RealtimeGraphKinectPatientComecarAGravar()};
			// scenes["RealtimeGraphKinectPhysio"] = new Action[] {()=> RealtimeGraphKinectPhysiorotular(), ()=> RealtimeGraphKinectPhysiovoltar(), ()=> RealtimeGraphKinectPhysiodeletarRotulo(), ()=> RealtimeGraphKinectPhysioComecarAGravar()};
			// scenes["RealtimeGraphUDPPatient"] = new Action[] {()=> RealtimeGraphUDPPatientrotular(), ()=> RealtimeGraphUDPPatientvoltar(), ()=> RealtimeGraphUDPPatientdeletarRotulo(), ()=> RealtimeGraphUDPPatientComecarAGravar()};
			// scenes["RealtimeGraphUDPPhysio"] = new Action[] {()=> RealtimeGraphUDPPhysiorotular(), ()=> RealtimeGraphUDPPhysiovoltar(), ()=> RealtimeGraphUDPPhysiodeletarRotulo(), ()=> RealtimeGraphUDPPhysioComecarAGravar()};
			// scenes["NewPatient"] = new Action[] {()=> NewPatientVoltar(), ()=> NewPatientCancelar(), ()=> NewPatientSalvar(), ()=> NewPatientDeletarPaciente(), ()=> NewPatientVisualizarPaciente()};
			// scenes["Patient"] = new Action[] {()=> PatientVoltar(), ()=> PatientCancelar(), ()=> PatientEditar(), ()=> PatientSessoes()};
			// scenes["UpdatePatient"] = new Action[] {()=> UpdatePatientVoltar(), ()=> UpdatePatientSalvar()};
			// scenes["Sessions"] = new Action[] {()=> SessionsVoltar(), ()=> SessionsVisualizarSessao(), ()=> SessionsDeletarSessao(), ()=> SessionsNovaSessao()};
			// scenes["MovementsToReproduce"] = new Action[] {()=> MovementsToReproduceVoltar(), ()=> MovementsToReproduceEscolher()};
			// scenes["EndSession"] = new Action[] {()=> EndSessionVoltar(), ()=> EndSessionSalvar()};
			// scenes["Session"] = new Action[] {()=> SessionVerExercicios(), ()=> SessionVoltar()};
			// scenes["MovementsToReview"] = new Action[] {()=> MovementsToReviewVoltar(), ()=> MovementsToReviewEscolher()};
			// scenes["ExercisesToReview"] = new Action[] {()=> ExercisesToReviewVoltar(), ()=> ExercisesToReviewVisualizar(), ()=> ExercisesToReviewDeletar()};

			Flow.StaticLogin();
			yield return new WaitForSeconds(1f);
				
			var i = 0;			
			while (UnityEditor.EditorApplication.isPlaying == true)
			{
				var currentscene = SceneManager.GetActiveScene().name;
				if (scenes.ContainsKey(currentscene) && i < 120)
				{
					var thisSceneOptions = scenes[currentscene];

					System.Random randomGenerator = new System.Random();
					int choice = randomGenerator.Next(0, thisSceneOptions.Length-1);

					thisSceneOptions[choice].Invoke();

					yield return new WaitForSeconds(1f);
				}
				else
				{
					Flow.StaticQuit();
					//se teste nao quebrou em nenhum lugar, então tá tudo certo
					Assert.IsTrue(true);
					break;
				}
				i++;
			}
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