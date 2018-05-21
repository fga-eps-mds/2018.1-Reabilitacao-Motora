using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sessao;
using UnityEngine.SceneManagement;


public class SetSessionToButton : MonoBehaviour 
{

	private Sessao session;

	public void SelectSession ()
	{
		GlobalController.instance.session = session;
	}

	public Sessao Session
	{
		get 
		
		{
			return session;
		}
		set 
		{
			session = value; 
		}
	}
}
