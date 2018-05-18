using UnityEngine;
using UnityEngine.UI;

public class DestroyInstancePatient : MonoBehaviour 
{
	public void DestroyGameObjectPatient (int idRP)
	{
		var desc = gameObject.GetComponentInChildren<SetLabelPatient>().Prp.idRotuloPaciente;

		if (desc == idRP)
		{
			Destroy(gameObject);
			GlobalController.instance.prp = null;
		}
	}
}
