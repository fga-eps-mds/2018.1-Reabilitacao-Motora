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

	/**
	 * Leva para scene de gravar um movimento.
	 */
	public static void StaticNewMovement()
	{
		SceneManager.LoadScene("NewMovement");
	}

	/**
	 * Leva para scene de gravar um movimento.
	 */
	public static void StaticRealtimeGraphKinectPatient()
	{
		SceneManager.LoadScene("RealtimeGraphKinectPatient");
	}

	public static void StaticRealtimeGraphKinectPhysio()
	{
		SceneManager.LoadScene("RealtimeGraphKinectPhysio");
	}

	public static void StaticRealtimeGraphUDPPatient()
	{
		SceneManager.LoadScene("RealtimeGraphUDPPatient");
	}

	public static void StaticRealtimeGraphUDPPhysio()
	{
		SceneManager.LoadScene("RealtimeGraphUDPPhysio");
	}

	/**
	 * Leva para scene de detalhe de paciente.
	 */
	public static void StaticPatient()
	{
		SceneManager.LoadScene("Patient");
	}

	/**
	 * Leva para scene de tela de login.
	 */
	public static void StaticLogin()
	{
		SceneManager.LoadScene("Login");
	}


	/**
	 * Leva para scene de lista de movimentos.
	 */
	public static void StaticMovements()
	{
		SceneManager.LoadScene("Movements");
		SceneManager.LoadScene ("ClinicToMoveMenu", LoadSceneMode.Additive);
	}

    /**
     * Leva para scene de gravar um movimento.
     */
    public static void ChoiceSensor()
    {
        SceneManager.LoadScene("ChoiceSensor");
    }

    /**
	 * Leva para scene de registrar novo paciente.
	 */
    public static void StaticNewPatient()
	{
		SceneManager.LoadScene("NewPatient");
	}


	/**
	 * Leva para scene de registrar novo paciente.
	 */
	public static void StaticUpdatePatient()
	{
		SceneManager.LoadScene("UpdatePatient");
	}


	/**
	 * Leva para scene de detalhes de sessão.
	 */
	public static void StaticSession()
	{
		SceneManager.LoadScene("Session");
	}


	/**
	 * Leva para scene de lista de sessões.
	 */
	public static void StaticSessions()
	{
		SceneManager.LoadScene("Sessions");
	}


	/**
	 * Leva para scene de função não implementada.
	 */
	public static void StaticNotImplemented()
	{
		SceneManager.LoadScene("NotImplemented");
	}


	/**
	 * Leva para scene de gráficos.
	 */
	public static void StaticGraphs2()
	{
		SceneManager.LoadScene("Graphs2");
	}


	/**
	 * Volta para o menu.
	 */
	public static void StaticMenu()
	{
		SceneManager.LoadScene("Menu");
	}



	/**
	 * Leva para a scene de novo fisioterapeuta.
	 */
	public static void StaticNewPhysiotherapist()
	{
		SceneManager.LoadScene("NewPhysiotherapist");
	}



	/**
	 * Leva para a scene de nova sessao.
	 */
	public static void StaticNewSession()
	{
		SceneManager.LoadScene("NewSession");
	}



	/**
	 * Leva para a scene que lista os movimentos passíveis de serem reproduzidos num exercício.
	 */
	public static void StaticMovementsToExercise()
	{
		SceneManager.LoadScene("MovementsToExercise");
	}



	/**
	 * Leva para a scene que lista os movimentos passíveis de serem reproduzidos num exercício.
	 */
	public static void StaticEndSession()
	{
		SceneManager.LoadScene("EndSession");
	}



	/**
	 * Leva para a scene que lista os movimentos passíveis de serem reproduzidos num exercício.
	 */
	public static void StaticMovementsToReview()
	{
		SceneManager.LoadScene("MovementsToReview");
	}



	/**
	 * Leva para a scene que lista os movimentos passíveis de serem reproduzidos num exercício.
	 */
	public static void StaticExercisesToReview()
	{
		SceneManager.LoadScene("ExercisesToReview");
	}



	/**
	 * Leva para a scene que lista os movimentos passíveis de serem reproduzidos num exercício.
	 */
	public static void StaticGraphs1()
	{
		SceneManager.LoadScene("Graphs1");
	}

	/**
	 * Leva para a scene que lista os movimentos passíveis de serem reproduzidos num exercício.
	 */
	public static void StaticGraphs3()
	{
		SceneManager.LoadScene("Graphs3");
	}

}
