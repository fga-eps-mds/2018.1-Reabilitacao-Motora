using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using pontosrotulofisioterapeuta;

public class DeleteLabelButtonPhysio : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{DeleteLabelPhysio();});
	}

	public static void DeleteLabelPhysio ()
	{
		int IdPRF = GlobalController.instance.prf.idRotuloFisioterapeuta;
		PontosRotuloFisioterapeuta.DeleteValue (IdPRF);

		GameObject[] labels = GameObject.FindGameObjectsWithTag("label");
		
		foreach (var l in labels)
		{
			var scripto = l.GetComponent<DestroyInstancePhysio>();
			scripto.DestroyGameObjectPhysio(IdPRF);
		}
	}
}
