using UnityEngine;
using UnityEngine.UI;

public class DestroyInstance : MonoBehaviour 
{
	public static DestroyInstance instance;

	// public GameObject self;
	
	private void Awake ()
	{
		instance = this;
	}

	public static void DestroyGameObject()
	{
		var desc = instance.GetComponentInChildren<SetLabel>().Prp.idRotuloPaciente;
		if (desc == GlobalController.instance.prp.idRotuloPaciente)
		{
	    	Destroy(instance.gameObject);
	    	GlobalController.instance.prp = null;
		}
	}
}
