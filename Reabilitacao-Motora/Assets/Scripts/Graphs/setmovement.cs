using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using movimento;
using UnityEngine.SceneManagement;


public class setmovement : MonoBehaviour {

	public Movimento x;

	public void setemovement ()
	{
		GlobalController.instance.movement = x;
		SceneManager.LoadScene("Graphs2");
	}
}
