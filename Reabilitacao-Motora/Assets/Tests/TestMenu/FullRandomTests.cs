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
		public static void LoginEnter(){}
		public static void LoginCadastrar(){}
		public static void LoginSair(){}
		
		public static void NewPhysiotherapistVoltar(){}
		public static void NewPhysiotherapistSalvar(){}
		public static void NewPhysiotherapistCancelar(){}
		
		public static void MenuPaciente(){}
		public static void MenuMovimentos(){}
		public static void MenuAjuda(){}
		public static void MenuSair(){}
		
		public static void MovementsVoltar(){}
		public static void MovementsVisualizarMovimento(){}
		public static void MovementsDeletarMovimento(){}
		public static void MovementsGravarMovimento(){}
		
		public static void NewMovementVoltar(){}
		public static void NewMovementSalvar(){}
		public static void NewMovementCancelar(){}
		
		public static void ChoiceSensorVoltar(){}
		public static void ChoiceSensorEscolherSensor(){}

		public static void RealtimeGraphKinectPatientvoltar(){}
		public static void RealtimeGraphKinectPatientrotular(){}
		public static void RealtimeGraphKinectPatientdeletarRotulo(){}
		public static void RealtimeGraphKinectPatientComecarAGravar(){}

		public static void RealtimeGraphKinectPhysiovoltar(){}
		public static void RealtimeGraphKinectPhysiorotular(){}
		public static void RealtimeGraphKinectPhysiodeletarRotulo(){}
		public static void RealtimeGraphKinectPhysioComecarAGravar(){}

		public static void RealtimeGraphUDPPatientvoltar(){}
		public static void RealtimeGraphUDPPatientrotular(){}
		public static void RealtimeGraphUDPPatientdeletarRotulo(){}
		public static void RealtimeGraphUDPPatientComecarAGravar(){}

		public static void RealtimeGraphUDPPhysiovoltar(){}
		public static void RealtimeGraphUDPPhysiorotular(){}
		public static void RealtimeGraphUDPPhysiodeletarRotulo(){}
		public static void RealtimeGraphUDPPhysioComecarAGravar(){}

		public static void NewPatientVoltar(){}
		public static void NewPatientSalvar(){}
		public static void NewPatientCancelar(){}
		public static void NewPatientVisualizarPaciente(){}
		public static void NewPatientDeletarPaciente(){}

		public static void PatientVoltar(){}
		public static void PatientCancelar(){}
		public static void PatientEditar(){}
		public static void PatientSessoes(){}

		public static void UpdatePatientSalvar(){}
		public static void UpdatePatientVoltar(){}

		public static void SessionsVoltar(){}
		public static void SessionsVisualizarSessao(){}
		public static void SessionsDeletarSessao(){}
		public static void SessionsNovaSessao(){}

		public static void NewSessionFinalizarSessao(){}
		public static void NewSessionAdicionarObservacao(){}
		public static void NewSessionCadastrarNovoExercicio(){}
		public static void NewSessionVoltar(){}

		public static void MovementsToReproduceVoltar(){}
		public static void MovementsToReproduceEscolher(){}

		public static void EndSessionSalvar(){}
		public static void EndSessionVoltar(){}

		public static void SessionVerExercicios(){}
		public static void SessionVoltar(){}

		public static void MovementsToReviewVoltar(){}
		public static void MovementsToReviewEscolher(){}

		public static void ExercisesToReviewVoltar(){}
		public static void ExercisesToReviewVisualizar(){}
		public static void ExercisesToReviewDeletar(){}


		[UnityTest]
		public static IEnumerator TestDeleteMovement()
		{
			var scenes = new Dictionary<string, Action[]>();
			scenes["Login"] = new Action[] {()=> LoginEnter(), ()=> LoginCadastrar(), ()=> LoginSair()};
			scenes["NewPhysiotherapist"] = new Action[] {()=> NewPhysiotherapistCancelar(), ()=> NewPhysiotherapistSalvar(), ()=> NewPhysiotherapistVoltar()};
			scenes["Menu"] = new Action[] {()=> MenuSair(), ()=> MenuAjuda(), ()=> MenuMovimentos(), ()=> MenuPaciente()};
			scenes["Movements"] = new Action[] {()=> MovementsVoltar(), ()=> MovementsGravarMovimento(), ()=> MovementsDeletarMovimento(), ()=> MovementsVisualizarMovimento()};
			scenes["NewMovement"] = new Action[] {()=> NewMovementCancelar(), ()=> NewMovementSalvar(), ()=> NewMovementVoltar()};
			scenes["ChoiceSensor"] = new Action[] {()=> ChoiceSensorVoltar(), ()=> ChoiceSensorEscolherSensor()};
			scenes["RealtimeGraphKinectPatient"] = new Action[] {()=> RealtimeGraphKinectPatientrotular(), ()=> RealtimeGraphKinectPatientvoltar(), ()=> RealtimeGraphKinectPatientdeletarRotulo(), ()=> RealtimeGraphKinectPatientComecarAGravar()};
			scenes["RealtimeGraphKinectPhysio"] = new Action[] {()=> RealtimeGraphKinectPhysiorotular(), ()=> RealtimeGraphKinectPhysiovoltar(), ()=> RealtimeGraphKinectPhysiodeletarRotulo(), ()=> RealtimeGraphKinectPhysioComecarAGravar()};
			scenes["RealtimeGraphUDPPatient"] = new Action[] {()=> RealtimeGraphUDPPatientrotular(), ()=> RealtimeGraphUDPPatientvoltar(), ()=> RealtimeGraphUDPPatientdeletarRotulo(), ()=> RealtimeGraphUDPPatientComecarAGravar()};
			scenes["RealtimeGraphUDPPhysio"] = new Action[] {()=> RealtimeGraphUDPPhysiorotular(), ()=> RealtimeGraphUDPPhysiovoltar(), ()=> RealtimeGraphUDPPhysiodeletarRotulo(), ()=> RealtimeGraphUDPPhysioComecarAGravar()};
			scenes["NewPatient"] = new Action[] {()=> NewPatientVoltar(), ()=> NewPatientCancelar(), ()=> NewPatientSalvar(), ()=> NewPatientDeletarPaciente(), ()=> NewPatientVisualizarPaciente()};
			scenes["Patient"] = new Action[] {()=> PatientVoltar(), ()=> PatientCancelar(), ()=> PatientEditar(), ()=> PatientSessoes()};
			scenes["UpdatePatient"] = new Action[] {()=> UpdatePatientVoltar(), ()=> UpdatePatientSalvar()};
			scenes["Sessions"] = new Action[] {()=> SessionsVoltar(), ()=> SessionsVisualizarSessao(), ()=> SessionsDeletarSessao(), ()=> SessionsNovaSessao()};
			scenes["MovementsToReproduce"] = new Action[] {()=> MovementsToReproduceVoltar(), ()=> MovementsToReproduceEscolher()};
			scenes["EndSession"] = new Action[] {()=> EndSessionVoltar(), ()=> EndSessionSalvar()};
			scenes["Session"] = new Action[] {()=> SessionVerExercicios(), ()=> SessionVoltar()};
			scenes["MovementsToReview"] = new Action[] {()=> MovementsToReviewVoltar(), ()=> MovementsToReviewEscolher()};
			scenes["ExercisesToReview"] = new Action[] {()=> ExercisesToReviewVoltar(), ()=> ExercisesToReviewVisualizar(), ()=> ExercisesToReviewDeletar()};

			Flow.StaticLogin();
			yield return new WaitForSeconds(1f);

			while (UnityEditor.EditorApplication.isPlaying)
			{
				var currentscene = SceneManager.GetActiveScene().name;
				var thisSceneOptions = scenes[currentscene];

				System.Random randomGenerator = new System.Random();
				int choice = randomGenerator.Next(0, thisSceneOptions.Length-1);

				thisSceneOptions[choice].Invoke();
			}
		}
	}
}