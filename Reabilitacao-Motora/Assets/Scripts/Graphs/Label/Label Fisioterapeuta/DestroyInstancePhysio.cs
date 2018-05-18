using UnityEngine;
using UnityEngine.UI;

public class DestroyInstancePhysio : MonoBehaviour 
{
	public void DestroyGameObjectPhysio (int idRF)
	{
		var desc = gameObject.GetComponentInChildren<SetLabelPhysio>().Prf.idRotuloFisioterapeuta;

		if (desc == idRF)
		{
			Destroy(gameObject);
			GlobalController.instance.prf = null;
		}
	}
}
