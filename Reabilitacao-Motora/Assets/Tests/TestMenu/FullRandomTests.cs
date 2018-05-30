// using System;
// using System.Linq;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;
// using UnityEngine.TestTools;
// using NUnit.Framework;
// using UnityEngine.EventSystems;
// using Mono.Data.Sqlite;
// using System.Text.RegularExpressions;

// using pessoa;
// using fisioterapeuta;
// using paciente;
// using musculo;
// using movimento;
// using sessao;
// using exercicio;
// using movimentomusculo;
// using pontosrotulofisioterapeuta;
// using pontosrotulopaciente;

// namespace Tests
// {
// 	public static class FullRandomTests
// 	{
// 		[SetUp]
// 		public static void BeforeEveryTest ()
// 		{
// 			GlobalController.test = true;
// 			GlobalController.Initialize();
// 		}

// 		public static void LoginEnter()
// 		{
// 			LoginCancelarSair();
// 			var button = GameObject.Find("/Canvas/Panel/LoginBt").GetComponent<Button>();

// 			var input1 = GameObject.Find("/Canvas/Panel/InputFieldLogin").GetComponentInChildren<InputField>();
// 			input1.text = "seloco";
// 			var input2 = GameObject.Find("/Canvas/Panel/InputFieldPassword").GetComponentInChildren<InputField>();
// 			input2.text = "rapaziada";

// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}

// 		public static void LoginCadastrar()
// 		{
// 			LoginCancelarSair();
// 			var button = GameObject.Find("/Canvas/Panel/RegisterBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}

// 		public static void LoginSair()
// 		{
// 			LoginCancelarSair();
// 			var button = GameObject.Find("/Canvas/Quit").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}

// 		public static void LoginCancelarSair()
// 		{
// 			bool active = GameObject.Find("/Canvas/PanelDelete/CancelBt");
// 			if (active)
// 			{
// 				var button = GameObject.Find("/Canvas/PanelDelete/CancelBt").GetComponent<Button>();
// 				button.OnPointerClick(new PointerEventData(EventSystem.current));
// 			}
// 		}

// 		public static void NewPhysiotherapistVoltar()
// 		{
// 			NewPhysiotherapistOkPopUp();
// 			var button = GameObject.Find("/Canvas/BackBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}

// 		public static void NewPhysiotherapistSalvar()
// 		{
// 			NewPhysiotherapistOkPopUp();
// 			bool notregistered = true;
// 			var fisios = Fisioterapeuta.Read();
// 			foreach(var fisio in fisios)
// 			{
// 				if (fisio.login == "seloco")
// 				{
// 					notregistered = false;
// 				}
// 			}

// 			var button = GameObject.Find("/Canvas/PanelPhysiotherapist/SaveBt").GetComponent<Button>();

// 			if (notregistered)
// 			{

// 				var input1 = GameObject.Find("/Canvas/PanelPhysiotherapist/InputFieldName").GetComponentInChildren<InputField>();
// 				input1.text = "Joao Carioca";
// 				var toggle = GameObject.Find("/Canvas/PanelPhysiotherapist/ToggleMale").GetComponentInChildren<Toggle>();
// 				toggle.isOn = true;
// 				var input2 = GameObject.Find("/Canvas/PanelPhysiotherapist/InputFieldDateOfBirth").GetComponentInChildren<InputField>();
// 				input2.text = "10/10/1990";
// 				var input3 = GameObject.Find("/Canvas/PanelPhysiotherapist/InputFieldPhone1").GetComponentInChildren<InputField>();
// 				input3.text = "6196825656";
// 				var input4 = GameObject.Find("/Canvas/PanelPhysiotherapist/InputFieldLogin").GetComponentInChildren<InputField>();
// 				input4.text = "seloco";
// 				var input5 = GameObject.Find("/Canvas/PanelPhysiotherapist/InputFieldPassword").GetComponentInChildren<InputField>();
// 				input5.text = "rapaziada";
// 				var input6 = GameObject.Find("/Canvas/PanelPhysiotherapist/InputFieldConfirmPassword").GetComponentInChildren<InputField>();
// 				input6.text = "rapaziada";
// 			}
			
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}

// 		public static void NewPhysiotherapistCancelar()
// 		{
// 			NewPhysiotherapistOkPopUp();
// 			var button = GameObject.Find("/Canvas/PanelPhysiotherapist/CancelBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}

// 		public static void NewPhysiotherapistAjuda()
// 		{
// 			NewPhysiotherapistOkPopUp();
// 			var button = GameObject.Find("/Canvas/Help").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}
		
// 		public static void NewPhysiotherapistOkPopUp()
// 		{
// 			bool active = GameObject.Find("/Canvas/PanelValidation/OkBt");
// 			if (active)
// 			{
// 				var button = GameObject.Find("/Canvas/PanelValidation/OkBt").GetComponent<Button>();
// 				button.OnPointerClick(new PointerEventData(EventSystem.current));
// 			}
// 		}

// 		public static void MenuPaciente()
// 		{
// 			var button = GameObject.Find("/Canvas/PacientsBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}

// 		public static void MenuMovimentos()
// 		{
// 			var button = GameObject.Find("/Canvas/MovesBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}

// 		public static void MenuAjuda()
// 		{
// 			var button = GameObject.Find("/Canvas/HelpBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}

// 		public static void MenuSair()
// 		{
// 			var button = GameObject.Find("/Canvas/ExitBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}
		
// 		public static void MovementsVoltar()
// 		{
// 			MovementsCancelarDeletarMovimento();
// 			var button = GameObject.Find("/Canvas/BackBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}

// 		public static void MovementsVisualizarMovimento()
// 		{
// 			MovementsCancelarDeletarMovimento();
// 			bool active = GameObject.Find("/Canvas/MovimentoMovements(Clone)/movimento");
// 			if (active)
// 			{
// 				var button = GameObject.Find("/Canvas/MovimentoMovements(Clone)/movimento").GetComponent<Button>();
// 				button.OnPointerClick(new PointerEventData(EventSystem.current));
// 			}
// 		}

// 		public static void MovementsDeletarMovimento()
// 		{
// 			MovementsCancelarDeletarMovimento();
// 			bool active = GameObject.Find("/Canvas/MovimentoMovements(Clone)/DeleteBt");
// 			if (active)
// 			{
// 				var button = GameObject.Find("/Canvas/MovimentoMovements(Clone)/DeleteBt").GetComponent<Button>();
// 				button.OnPointerClick(new PointerEventData(EventSystem.current));
// 			}
// 		}

// 		public static void MovementsCancelarDeletarMovimento()
// 		{
// 			bool active = GameObject.Find("/Canvas/PanelDelete/CancelBt");
// 			if (active)
// 			{
// 				var button = GameObject.Find("/Canvas/PanelDelete/CancelBt").GetComponent<Button>();
// 				button.OnPointerClick(new PointerEventData(EventSystem.current));
// 			}
// 		}

// 		public static void MovementsConfirmarDeletarMovimento()
// 		{
// 			bool active = GameObject.Find("/Canvas/PanelDelete/DeleteBt");
// 			if (active)
// 			{
// 				var button = GameObject.Find("/Canvas/PanelDelete/DeleteBt").GetComponent<Button>();
// 				button.OnPointerClick(new PointerEventData(EventSystem.current));
// 			}
// 		}

// 		public static void MovementsGravarMovimento()
// 		{
// 			MovementsCancelarDeletarMovimento();
// 			var button = GameObject.Find("/Canvas/Gravar Movimento").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}
		
// 		public static void NewMovementVoltar()
// 		{
// 			var button = GameObject.Find("/Canvas/BackBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}

// 		public static void NewMovementSalvar()
// 		{
// 			var button = GameObject.Find("/Canvas/PanelShowPatient/SaveBt").GetComponent<Button>();

// 			bool notregistered = true;
// 			var moves = Movimento.Read();
// 			foreach(var mov in moves)
// 			{
// 				if (mov.nomeMovimento == "Movimento Tester")
// 				{
// 					notregistered = false;
// 				}
// 			}

// 			if (notregistered)
// 			{
// 				var input1 = GameObject.Find("/Canvas/PanelShowPatient/InputFieldName").GetComponentInChildren<InputField>();
// 				input1.text = "Movimento Tester";
// 				var input2 = GameObject.Find("/Canvas/PanelShowPatient/InputFieldMusculos").GetComponentInChildren<InputField>();
// 				input2.text = "Musculo Testier";
// 				var input3 = GameObject.Find("/Canvas/PanelShowPatient/InputFieldNotes").GetComponentInChildren<InputField>();
// 				input3.text = "haHaAhAHaHAa";
// 			}
			
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}

// 		public static void NewMovementCancelar()
// 		{
// 			var button = GameObject.Find("/Canvas/PanelShowPatient/CancelBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}
		
// 		public static void ChoiceSensorVoltar()
// 		{
// 			var button = GameObject.Find("/Canvas/BackBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}

// 		public static void ChoiceSensorEscolherSensor()
// 		{
// 			System.Random randomGenerator = new System.Random();
// 			int choice = randomGenerator.Next(0, 1);

// 			var dropdown = GameObject.Find("/Canvas/Dropdown").GetComponent<Dropdown>();
// 			dropdown.value = choice;

// 			var button = GameObject.Find("/Canvas/ConfirmBt").GetComponent<Button>();

// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}

// 		public static void AjudaVoltar ()
// 		{
// 			var button = GameObject.Find("/Canvas/Back").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}

// 		public static void RealtimeGraphKinectPatientvoltar()
// 		{
// 			RealtimeGraphKinectPatientCancelardeletarRotulo();
// 			var button = GameObject.Find("/Canvas/BackBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));	
// 		}

// 		public static void RealtimeGraphKinectPatientrotular()
// 		{
// 			RealtimeGraphKinectPatientCancelardeletarRotulo();
// 			var script = GameObject.Find("/Grafico").GetComponent<CreateLabelPatient>();

// 			bool notregistered = true;

// 			var prps = PontosRotuloPaciente.Read();
// 			foreach(var prp in prps)
// 			{
// 				if (prp.estagioMovimentoPaciente == "Label Patient Test")
// 				{
// 					notregistered = false;
// 				}
// 			}

// 			if (notregistered)
// 			{
// 				script.displayGraph("Label Patient Test", new Vector2(5f, 9f));
// 			}
// 		}

// 		public static void RealtimeGraphKinectPatientdeletarRotulo()
// 		{
// 			RealtimeGraphKinectPatientCancelardeletarRotulo();
// 			bool active = GameObject.Find("/Grafico/RotuloPaciente(Clone)/Description/Canvas/DeleteButton");
// 			if (active)
// 			{
// 				var button = GameObject.Find("/Grafico/RotuloPaciente(Clone)/Description/Canvas/DeleteButton").GetComponent<Button>();
// 				button.OnPointerClick(new PointerEventData(EventSystem.current));
// 			}
// 		}

// 		public static void RealtimeGraphKinectPatientCancelardeletarRotulo()
// 		{
// 			bool active = GameObject.Find("/Canvas/PanelDeletePatient/CancelBt");
// 			if (active)
// 			{
// 				var button = GameObject.Find("/Canvas/PanelDeletePatient/CancelBt").GetComponent<Button>();
// 				button.OnPointerClick(new PointerEventData(EventSystem.current));
// 			}
// 		}

// 		public static void RealtimeGraphKinectPatientConfirmardeletarRotulo()
// 		{
// 			bool active = GameObject.Find("/Canvas/PanelDeletePatient/DeleteBt");
// 			if (active)
// 			{
// 				var button = GameObject.Find("/Canvas/PanelDeletePatient/DeleteBt").GetComponent<Button>();
// 				button.OnPointerClick(new PointerEventData(EventSystem.current));
// 			}
// 		}

// 		public static void RealtimeGraphKinectPatientComecarAGravar()
// 		{
// 			RealtimeGraphKinectPatientCancelardeletarRotulo();
// 			var script = GameObject.Find("/Grafico").GetComponent<GenerateLineChartRealTime>();
// 			script.SetMemberValue("t", true);
// 		}

// 		public static void RealtimeGraphKinectPhysiovoltar()
// 		{
// 			RealtimeGraphKinectPhysioCancelardeletarRotulo();	
// 			var button = GameObject.Find("/Canvas/BackBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}

// 		public static void RealtimeGraphKinectPhysiorotular()
// 		{
// 			RealtimeGraphKinectPhysioCancelardeletarRotulo();
// 			var script = GameObject.Find("/Grafico").GetComponent<CreateLabelPatient>();

// 			bool notregistered = true;

// 			var prps = PontosRotuloFisioterapeuta.Read();
// 			foreach(var prp in prps)
// 			{
// 				if (prp.estagioMovimentoFisio == "Label Fisio Test")
// 				{
// 					notregistered = false;
// 				}
// 			}

// 			if (notregistered)
// 			{
// 				script.displayGraph("Label Fisio Test", new Vector2(1f, 4f));
// 			}
// 		}

// 		public static void RealtimeGraphKinectPhysiodeletarRotulo()
// 		{
// 			RealtimeGraphKinectPhysioCancelardeletarRotulo();
// 			bool active = GameObject.Find("/Grafico/RotuloFisioterapeuta(Clone)/Description/Canvas/DeleteButton");
// 			if (active)
// 			{
// 				var button = GameObject.Find("/Grafico/RotuloFisioterapeuta(Clone)/Description/Canvas/DeleteButton").GetComponent<Button>();
// 				button.OnPointerClick(new PointerEventData(EventSystem.current));
// 			}
// 		}

// 		public static void RealtimeGraphKinectPhysioCancelardeletarRotulo()
// 		{
// 			bool active = GameObject.Find("/Canvas/PanelDeleteFisio/CancelBt");
// 			if (active)
// 			{
// 				var button = GameObject.Find("/Canvas/PanelDeleteFisio/CancelBt").GetComponent<Button>();
// 				button.OnPointerClick(new PointerEventData(EventSystem.current));
// 			}
// 		}

// 		public static void RealtimeGraphKinectPhysioConfirmardeletarRotulo()
// 		{
// 			bool active = GameObject.Find("/Canvas/PanelDeleteFisio/DeleteBt");
// 			if (active)
// 			{
// 				var button = GameObject.Find("/Canvas/PanelDeleteFisio/DeleteBt").GetComponent<Button>();
// 				button.OnPointerClick(new PointerEventData(EventSystem.current));
// 			}
// 		}

// 		public static void RealtimeGraphKinectPhysioComecarAGravar()
// 		{
// 			RealtimeGraphKinectPhysioCancelardeletarRotulo();
// 			var script = GameObject.Find("/Grafico").GetComponent<GenerateLineChartRealTime>();
// 			script.SetMemberValue("t", true);
// 		}

// 		public static void RealtimeGraphUDPPatientvoltar()
// 		{
// 			RealtimeGraphUDPPatientCancelardeletarRotulo();
// 			var button = GameObject.Find("/Canvas/BackBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}

// 		public static void RealtimeGraphUDPPatientrotular()
// 		{
// 			RealtimeGraphUDPPatientCancelardeletarRotulo();
// 			var script = GameObject.Find("/Grafico").GetComponent<CreateLabelPatient>();

// 			bool notregistered = true;

// 			var prps = PontosRotuloPaciente.Read();
// 			foreach(var prp in prps)
// 			{
// 				if (prp.estagioMovimentoPaciente == "Label Patient Test")
// 				{
// 					notregistered = false;
// 				}
// 			}

// 			if (notregistered)
// 			{
// 				script.displayGraph("Label Patient Test", new Vector2(5f, 9f));
// 			}
// 		}

// 		public static void RealtimeGraphUDPPatientdeletarRotulo()
// 		{
// 			RealtimeGraphUDPPatientCancelardeletarRotulo();
// 			bool active = GameObject.Find("/Grafico/RotuloFisioterapeuta(Clone)/Description/Canvas/DeleteButton");
// 			if (active)
// 			{
// 				var button = GameObject.Find("/Grafico/RotuloFisioterapeuta(Clone)/Description/Canvas/DeleteButton").GetComponent<Button>();
// 				button.OnPointerClick(new PointerEventData(EventSystem.current));
// 			}
// 		}

// 		public static void RealtimeGraphUDPPatientCancelardeletarRotulo()
// 		{
// 			bool active = GameObject.Find("/Canvas/PanelDeletePatient/CancelBt");
// 			if (active)
// 			{
// 				var button = GameObject.Find("/Canvas/PanelDeletePatient/CancelBt").GetComponent<Button>();
// 				button.OnPointerClick(new PointerEventData(EventSystem.current));
// 			}
// 		}

// 		public static void RealtimeGraphUDPPatientConfirmardeletarRotulo()
// 		{
// 			bool active = GameObject.Find("/Canvas/PanelDeletePatient/DeleteBt");
// 			if (active)
// 			{
// 				var button = GameObject.Find("/Canvas/PanelDeletePatient/DeleteBt").GetComponent<Button>();
// 				button.OnPointerClick(new PointerEventData(EventSystem.current));
// 			}
// 		}

// 		public static void RealtimeGraphUDPPatientComecarAGravar()
// 		{
// 			var script = GameObject.Find("/Grafico").GetComponent<GenerateLineChartRealTime>();
// 			script.SetMemberValue("t", true);
// 		}

// 		public static void RealtimeGraphUDPPhysiovoltar()
// 		{
// 			RealtimeGraphUDPPatientCancelardeletarRotulo();
// 			var button = GameObject.Find("/Canvas/BackBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}

// 		public static void RealtimeGraphUDPPhysiorotular()
// 		{
// 			RealtimeGraphUDPPatientCancelardeletarRotulo();
// 			var script = GameObject.Find("/Grafico").GetComponent<CreateLabelPatient>();

// 			bool notregistered = true;

// 			var prps = PontosRotuloFisioterapeuta.Read();
// 			foreach(var prp in prps)
// 			{
// 				if (prp.estagioMovimentoFisio == "Label Fisio Test")
// 				{
// 					notregistered = false;
// 				}
// 			}

// 			if (notregistered)
// 			{
// 				script.displayGraph("Label Fisio Test", new Vector2(1f, 4f));
// 			}
// 		}

// 		public static void RealtimeGraphUDPPhysiodeletarRotulo()
// 		{
// 			RealtimeGraphUDPPatientCancelardeletarRotulo();
// 			bool active = GameObject.Find("/Grafico/RotuloFisioterapeuta(Clone)/Description/Canvas/DeleteButton");
// 			if (active)
// 			{
// 				var button = GameObject.Find("/Grafico/RotuloFisioterapeuta(Clone)/Description/Canvas/DeleteButton").GetComponent<Button>();
// 				button.OnPointerClick(new PointerEventData(EventSystem.current));
// 			}
// 		}

// 		public static void RealtimeGraphUDPPhysioCancelardeletarRotulo()
// 		{
// 			bool active = GameObject.Find("/Canvas/PanelDeleteFisio/CancelBt");
// 			if (active)
// 			{
// 				var button = GameObject.Find("/Canvas/PanelDeleteFisio/CancelBt").GetComponent<Button>();
// 				button.OnPointerClick(new PointerEventData(EventSystem.current));
// 			}
// 		}

// 		public static void RealtimeGraphUDPPhysioConfirmardeletarRotulo()
// 		{
// 			bool active = GameObject.Find("/Canvas/PanelDeleteFisio/DeleteBt");
// 			if (active)
// 			{
// 				var button = GameObject.Find("/Canvas/PanelDeleteFisio/DeleteBt").GetComponent<Button>();
// 				button.OnPointerClick(new PointerEventData(EventSystem.current));
// 			}
// 		}


// 		public static void RealtimeGraphUDPPhysioComecarAGravar()
// 		{
// 			RealtimeGraphUDPPatientCancelardeletarRotulo();
// 			var script = GameObject.Find("/Grafico").GetComponent<GenerateLineChartRealTime>();
// 			script.SetMemberValue("t", true);
// 		}

// 		public static void NewPatientVoltar()
// 		{
// 			var button = GameObject.Find("/Canvas/BackBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}
// 		public static void NewPatientSalvar()
// 		{

// 		}
// 		public static void NewPatientCancelar()
// 		{

// 		}
// 		public static void NewPatientVisualizarPaciente()
// 		{

// 		}
// 		public static void NewPatientDeletarPaciente()
// 		{

// 		}

// 		public static void PatientVoltar()
// 		{
// 			var button = GameObject.Find("/Canvas/BackBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}
// 		public static void PatientCancelar()
// 		{

// 		}
// 		public static void PatientEditar()
// 		{

// 		}
// 		public static void PatientSessoes()
// 		{

// 		}

// 		public static void UpdatePatientSalvar()
// 		{

// 		}
// 		public static void UpdatePatientVoltar()
// 		{
// 			var button = GameObject.Find("/Canvas/BackBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}

// 		public static void SessionsVoltar()
// 		{
// 			var button = GameObject.Find("/Canvas/BackBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}
// 		public static void SessionsVisualizarSessao()
// 		{

// 		}
// 		public static void SessionsDeletarSessao()
// 		{

// 		}
// 		public static void SessionsNovaSessao()
// 		{

// 		}

// 		public static void NewSessionFinalizarSessao()
// 		{

// 		}
// 		public static void NewSessionAdicionarObservacao()
// 		{

// 		}
// 		public static void NewSessionCadastrarNovoExercicio()
// 		{

// 		}
// 		public static void NewSessionVoltar()
// 		{
// 			var button = GameObject.Find("/Canvas/BackBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}

// 		public static void MovementsToReproduceVoltar()
// 		{
// 			var button = GameObject.Find("/Canvas/BackBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}
// 		public static void MovementsToReproduceEscolher()
// 		{

// 		}

// 		public static void EndSessionSalvar()
// 		{

// 		}
// 		public static void EndSessionVoltar()
// 		{
// 			var button = GameObject.Find("/Canvas/BackBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}

// 		public static void SessionVerExercicios()
// 		{

// 		}
// 		public static void SessionVoltar()
// 		{
// 			var button = GameObject.Find("/Canvas/BackBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}

// 		public static void MovementsToReviewVoltar()
// 		{
// 			var button = GameObject.Find("/Canvas/BackBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}
// 		public static void MovementsToReviewEscolher()
// 		{

// 		}

// 		public static void ExercisesToReviewVoltar()
// 		{
// 			var button = GameObject.Find("/Canvas/BackBt").GetComponent<Button>();
// 			button.OnPointerClick(new PointerEventData(EventSystem.current));
// 		}
// 		public static void ExercisesToReviewVisualizar()
// 		{

// 		}
// 		public static void ExercisesToReviewDeletar()
// 		{

// 		}


// 		[UnityTest]
// 		[Timeout(100000000)]
// 		public static IEnumerator TestRandom()
// 		{
//  			var scenes = new Dictionary<string, Action[]>();
// 			scenes["Login"] = new Action[] {()=> LoginEnter(), ()=> LoginCadastrar(), ()=> LoginSair(), ()=> LoginCancelarSair()};
// 			scenes["NewPhysiotherapist"] = new Action[] {()=> NewPhysiotherapistCancelar(), ()=> NewPhysiotherapistSalvar(), ()=> NewPhysiotherapistVoltar(), ()=> NewPhysiotherapistAjuda(), ()=> NewPhysiotherapistOkPopUp()};
// 			scenes["Menu"] = new Action[] {()=> MenuMovimentos()};
// 			// scenes["Menu"] = new Action[] {()=> MenuSair(), ()=> MenuAjuda(), ()=> MenuMovimentos(), ()=> MenuPaciente()};
// 			scenes["Movements"] = new Action[] {()=> MovementsVoltar(), ()=> MovementsGravarMovimento(), ()=> MovementsDeletarMovimento(), ()=> MovementsVisualizarMovimento(), ()=> MovementsCancelarDeletarMovimento(), ()=> MovementsConfirmarDeletarMovimento()};
// 			scenes["NewMovement"] = new Action[] {()=> NewMovementCancelar(), ()=> NewMovementSalvar(), ()=> NewMovementVoltar()};
// 			scenes["ChoiceSensor"] = new Action[] {()=> ChoiceSensorEscolherSensor()};
// 			scenes["NotImplemented"] = new Action[] {()=> AjudaVoltar()};
// 			scenes["RealtimeGraphKinectPatient"] = new Action[] {()=> RealtimeGraphKinectPatientrotular(), ()=> RealtimeGraphKinectPatientvoltar(), ()=> RealtimeGraphKinectPatientdeletarRotulo(), ()=> RealtimeGraphKinectPatientComecarAGravar(), ()=> RealtimeGraphKinectPatientCancelardeletarRotulo(), ()=> RealtimeGraphKinectPatientConfirmardeletarRotulo()};
// 			scenes["RealtimeGraphKinectPhysio"] = new Action[] {()=> RealtimeGraphKinectPhysiorotular(), ()=> RealtimeGraphKinectPhysiovoltar(), ()=> RealtimeGraphKinectPhysiodeletarRotulo(), ()=> RealtimeGraphKinectPhysioComecarAGravar(), ()=> RealtimeGraphKinectPhysioCancelardeletarRotulo(), ()=> RealtimeGraphKinectPhysioConfirmardeletarRotulo()};
// 			scenes["RealtimeGraphUDPPatient"] = new Action[] {()=> RealtimeGraphUDPPatientrotular(), ()=> RealtimeGraphUDPPatientvoltar(), ()=> RealtimeGraphUDPPatientdeletarRotulo(), ()=> RealtimeGraphUDPPatientComecarAGravar(), ()=> RealtimeGraphUDPPatientCancelardeletarRotulo(), ()=> RealtimeGraphUDPPatientConfirmardeletarRotulo()};
// 			scenes["RealtimeGraphUDPPhysio"] = new Action[] {()=> RealtimeGraphUDPPhysiorotular(), ()=> RealtimeGraphUDPPhysiovoltar(), ()=> RealtimeGraphUDPPhysiodeletarRotulo(), ()=> RealtimeGraphUDPPhysioComecarAGravar(), ()=> RealtimeGraphUDPPhysioCancelardeletarRotulo(), ()=> RealtimeGraphUDPPhysioConfirmardeletarRotulo()};
// 			// scenes["NewPatient"] = new Action[] {()=> NewPatientVoltar(), ()=> NewPatientCancelar(), ()=> NewPatientSalvar(), ()=> NewPatientDeletarPaciente(), ()=> NewPatientVisualizarPaciente()};
// 			// scenes["Patient"] = new Action[] {()=> PatientVoltar(), ()=> PatientCancelar(), ()=> PatientEditar(), ()=> PatientSessoes()};
// 			// scenes["UpdatePatient"] = new Action[] {()=> UpdatePatientVoltar(), ()=> UpdatePatientSalvar()};
// 			// scenes["Sessions"] = new Action[] {()=> SessionsVoltar(), ()=> SessionsVisualizarSessao(), ()=> SessionsDeletarSessao(), ()=> SessionsNovaSessao()};
// 			// scenes["MovementsToReproduce"] = new Action[] {()=> MovementsToReproduceVoltar(), ()=> MovementsToReproduceEscolher()};
// 			// scenes["EndSession"] = new Action[] {()=> EndSessionVoltar(), ()=> EndSessionSalvar()};
// 			// scenes["Session"] = new Action[] {()=> SessionVerExercicios(), ()=> SessionVoltar()};
// 			// scenes["MovementsToReview"] = new Action[] {()=> MovementsToReviewVoltar(), ()=> MovementsToReviewEscolher()};
// 			// scenes["ExercisesToReview"] = new Action[] {()=> ExercisesToReviewVoltar(), ()=> ExercisesToReviewVisualizar(), ()=> ExercisesToReviewDeletar()};

// 			Flow.StaticLogin();
// 			yield return new WaitForSeconds(1f);

// 			var i = 0;			
// 			while (UnityEditor.EditorApplication.isPlaying == true)
// 			{
// 				var currentscene = SceneManager.GetActiveScene().name;
				

// 				if (scenes.ContainsKey(currentscene) && i < 120)
// 				{
// 					var thisSceneOptions = scenes[currentscene];

// 					System.Random randomGenerator = new System.Random();
// 					int choice = randomGenerator.Next(0, thisSceneOptions.Length-1);

// 					if (currentscene.Substring(0, 4) == "Real" && choice == 4)
// 					{
// 						yield return new WaitForSeconds(6f);
// 					}

// 					thisSceneOptions[choice].Invoke();

// 					if (currentscene == "ChoiceSensor")
// 					{
// 						var device = @"^(.*?(\bDevice|Socket|SDK\b)[^$]*)$";
// 						Regex rgx1 = new Regex(device, RegexOptions.IgnoreCase);
// 						LogAssert.Expect(LogType.Error, rgx1);
// 					}

// 					yield return new WaitForSeconds(1f);
// 				}
// 				else
// 				{
// 					//se teste nao quebrou em nenhum lugar, então tá tudo certo
// 					Assert.IsTrue(true);
// 					break;
// 				}
// 				i++;
// 			}
// 		}

// 		[TearDown]
// 		public static void AfterEveryTest ()
// 		{
// 			SqliteConnection.ClearAllPools();
// 			GC.Collect();
// 			GC.WaitForPendingFinalizers();
// 			GlobalController.DropAll();
// 			GlobalController.instance = null;
// 		}
// 	}
// }