using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fluxo : MonoBehaviour {

	public void Quit()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit ();
		#endif
	}

	public void NotImplemented() {
		SceneManager.LoadScene ("NotImplemented");
	}

	public void BackToMenu() {
		SceneManager.LoadScene ("Menu");
	}
}