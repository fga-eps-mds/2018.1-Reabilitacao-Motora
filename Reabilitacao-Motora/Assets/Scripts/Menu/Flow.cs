using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/**
 * Escala o tamanho dos componentes da scene conforme o tamanho da tela.
 */
public class Flow : MonoBehaviour
{

	/**
 	 * Finaliza o programa ao clicar em sair.
 	 */
	public static void StaticQuit()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

	public void Quit()
	{
		StaticQuit();
	}

	/**
 	 * Leva para scene de gravar um movimento.
 	 */
	public static void StaticCreateMove()
	{
		SceneManager.LoadScene("NewMovement");
	}

	public void CreateMove()
	{
		StaticCreateMove();
	}


	/**
 	 * Leva para scene de gravar um movimento.
 	 */
	public static void StaticRecordMove()
	{
		SceneManager.LoadScene("Clinic");
	}

	public void RecordMove()
	{
		StaticRecordMove();
	}


	/**
 	 * Leva para scene de detalhe de paciente.
 	 */
	public static void StaticPatient()
	{
		SceneManager.LoadScene("Patient");
	}

	public void Patient()
	{
		StaticPatient();
	}

	/**
 	 * Leva para scene de lista de pacientes.
 	 */
	public static void StaticPatients()
	{
		SceneManager.LoadScene("Patients");
	}

	public void Patients()
	{
		StaticPatients();
	}

	/**
 	 * Leva para scene de tela de login.
 	 */
	public static void StaticLogin()
	{
		SceneManager.LoadScene("Login");
	}

	public void Login()
	{
		StaticLogin();
	}

    /**
 	 * Leva para scene de lista de movimentos.
 	 */
    public static void StaticMovements()
	{
		SceneManager.LoadScene("Movements");
		SceneManager.LoadScene ("ClinicToMoveMenu", LoadSceneMode.Additive);
	}

	public void Movements()
	{
		StaticMovements();
	}

	/**
 	 * Leva para scene de registrar novo paciente.
 	 */
	public static void StaticNewPatient()
	{
		SceneManager.LoadScene("NewPatient");
	}

	public void NewPatient()
	{
		StaticNewPatient();
	}

	/**
 	 * Leva para scene de registrar novo paciente.
 	 */
	public static void StaticUpdatePatient()
	{
		SceneManager.LoadScene("UpdatePatient");
	}

	public void UpdatePatient()
	{
		StaticUpdatePatient();
	}

	/**
 	 * Leva para scene de detalhes de sessão.
 	 */
	public static void StaticSession()
	{
		SceneManager.LoadScene("Session");
	}

	public void Session()
	{
		StaticSession();
	}

	/**
 	 * Leva para scene de lista de sessões.
 	 */
	public static void StaticSessions()
	{
		SceneManager.LoadScene("Sessions");
	}

	public void Sessions()
	{
		StaticSessions();
	}

	/**
 	 * Leva para scene de função não implementada.
 	 */
	public static void StaticNotImplemented()
	{
		SceneManager.LoadScene("NotImplemented");
	}

	public void NotImplemented()
	{
		StaticNotImplemented();
	}

	/**
 	 * Leva para scene de gráficos.
 	 */
	public static void StaticGraphs()
	{
		SceneManager.LoadScene("Graphs2");
	}

	public void Graphs()
	{
		StaticGraphs();
	}

    /**
 	 * Leva para scene de gráficos.
 	 */
	public static void StaticRealTimeGraphs()
	{
		SceneManager.LoadScene("RealtimeGraph");
	}

	public void RealTimeGraphs()
	{
		StaticRealTimeGraphs();
	}

	/**
 	 * Volta para o menu.
 	 */
	public static void StaticBackToMenu()
	{
		SceneManager.LoadScene("Menu");
	}

	public void BackToMenu()
	{
		StaticBackToMenu();
	}

	/**
 	 * Volta para o menu inicial.
 	 */
	public static void StaticBackToHomeMenu()
	{
		SceneManager.LoadScene("Login");
	}

	public void BackToHomeMenu()
	{
		StaticBackToHomeMenu();
	}

	/**
 	 * Leva para a scene de novo fisioterapeuta.
 	 */
	public static void StaticNewPhysiotherapist()
	{
		SceneManager.LoadScene("NewPhysiotherapist");
	}

	public void NewPhysiotherapist()
	{
		StaticNewPhysiotherapist();
	}

	/**
 	 * Leva para a scene sucess register.
 	 */
	public static void StaticSuccessRegister()
	{
		SceneManager.LoadScene("SuccessRegister");
	}

}
