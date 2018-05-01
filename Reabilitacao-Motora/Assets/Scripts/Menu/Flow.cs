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
	public void Quit()
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
	public void CreateMove() 
	{
		SceneManager.LoadScene("NewMovement");
	}

	/**
 	 * Leva para scene de gravar um movimento.
 	 */
	public void RecordMove() 
	{
		SceneManager.LoadScene("Clinic");
	}

	/**
 	 * Leva para scene de detalhe de paciente.
 	 */
	public void Patient() 
	{
		SceneManager.LoadScene("Patient");
	}

	/**
 	 * Leva para scene de lista de pacientes.
 	 */
	public void Patients() 
	{
		SceneManager.LoadScene("Patients");
	}

	/**
 	 * Leva para scene de tela de login.
 	 */
	public void Login() 
	{
		SceneManager.LoadScene("Login");
	}

    /**
 	 * Leva para scene de lista de movimentos.
 	 */
    public void Movements() 
	{
		SceneManager.LoadScene("Movements");
		SceneManager.LoadScene ("ClinicToMoveMenu", LoadSceneMode.Additive);
	}

	/**
 	 * Leva para scene de registrar novo paciente.
 	 */
	public void NewPatient() 
	{
		SceneManager.LoadScene("NewPatient");
	}

		/**
 	 * Leva para scene de registrar novo paciente.
 	 */
	public void UpdatePatient() 
	{
		SceneManager.LoadScene("UpdatePatient");
	}

	/**
 	 * Leva para scene de detalhes de sessão.
 	 */
	public void Session() 
	{
		SceneManager.LoadScene("Session");
	}

	/**
 	 * Leva para scene de lista de sessões.
 	 */
	public void Sessions() 
	{
		SceneManager.LoadScene("Sessions");
	}

	/**
 	 * Leva para scene de função não implementada.
 	 */
	public void NotImplemented() 
	{
		SceneManager.LoadScene("NotImplemented");
	}

	/**
 	 * Leva para scene de gráficos.
 	 */
	public void Graphs() 
	{
		SceneManager.LoadScene("Graphs2");
	}

    /**
 	 * Leva para scene de gráficos.
 	 */
	public void RealTimeGraphs() 
	{
		SceneManager.LoadScene("Realtime Graph");
	}

	/**
 	 * Volta para o menu.
 	 */
	public void BackToMenu() 
	{
		SceneManager.LoadScene("Menu");
	}

	/**
 	 * Volta para o menu inicial.
 	 */
	public void BackToHomeMenu()
	{
		SceneManager.LoadScene("Login");
	}

	/**
 	 * Leva para a scene de novo fisioterapeuta.
 	 */
	public void NewPhysiotherapist()
	{
		SceneManager.LoadScene("NewPhysiotherapist");
	}

	/**
 	 * Leva para a scene de gráfico em tempo real.
 	 */
	public void RealtimeGraph()
	{
		SceneManager.LoadScene("Realtime Graph");
	}

	/**
 	 * Leva para a scene sucess register.
 	 */
	public void SucessRegister()
	{
		SceneManager.LoadScene("sucessRegister");
	}
		
}