using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/**
 * Escala o tamanho dos componentes da scene conforme o tamanho da tela.
 */
public class Flow : MonoBehaviour {

	/**
 	 * Finaliza o programa ao clicar em sair.
 	 */
	public void Quit()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit ();
		#endif
	}

	/**
 	 * Leva para scene de função não implementada.
 	 */
	public void NotImplemented() {
		SceneManager.LoadScene ("NotImplemented");
	}

	/**
 	 * Volta para o menu.
 	 */
	public void BackToMenu() {
		SceneManager.LoadScene ("Menu");
	}
}