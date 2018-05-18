using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using pontosrotulopaciente;

public class DeleteLabelButtonPatient : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{DeleteLabelPatient();});
	}

	public static void DeleteLabelPatient ()
	{
		int IdPRP = GlobalController.instance.prp.idRotuloPaciente;
		PontosRotuloPaciente.DeleteValue (IdPRP);

		GameObject[] labels = GameObject.FindGameObjectsWithTag("label");
		
		foreach (var l in labels)
		{
			var scripto = l.GetComponent<DestroyInstancePatient>();
			scripto.DestroyGameObjectPatient (IdPRP);
		}
	}
}
