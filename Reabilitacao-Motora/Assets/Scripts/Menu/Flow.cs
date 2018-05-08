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
	public static void StaticNewMovement()
	{
		SceneManager.LoadScene("NewMovement");
	}

	public void NewMovement()
	{
		StaticNewMovement();
	}


	/**
 	 * Leva para scene de gravar um movimento.
 	 */
	public static void StaticClinic()
	{
		SceneManager.LoadScene("Clinic");
	}

	public void Clinic()
	{
		StaticClinic();
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
	public static void StaticGraphs2()
	{
		SceneManager.LoadScene("Graphs2");
	}

	public void Graphs2()
	{
		StaticGraphs2();
	}

    /**
 	 * Leva para scene de gráficos.
 	 */
	public static void StaticRealtimeGraph()
	{
		SceneManager.LoadScene("RealtimeGraph");
	}

	public void RealtimeGraph()
	{
		StaticRealtimeGraph();
	}

	/**
 	 * Volta para o menu.
 	 */
	public static void StaticMenu()
	{
		SceneManager.LoadScene("Menu");
	}

	public void Menu()
	{
		StaticMenu();
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
 	 * Leva para a scene de nova sessao.
 	 */
	public static void StaticNewSession()
	{
		SceneManager.LoadScene("NewSession");
	}

	public void NewSession()
	{
		StaticNewSession();
	}


	/**
 	 * Leva para a scene que lista os movimentos passíveis de serem reproduzidos num exercício.
 	 */
	public static void StaticMovementsToExercise()
	{
		SceneManager.LoadScene("MovementsToExercise");
	}

	public void MovementsToExercise()
	{
		StaticMovementsToExercise();
	}


	/**
 	 * Leva para a scene que lista os movimentos passíveis de serem reproduzidos num exercício.
 	 */
	public static void StaticEndSession()
	{
		SceneManager.LoadScene("EndSession");
	}

	public void EndSession()
	{
		StaticEndSession();
	}
}
