using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using pontosrotulopaciente;

public class DeleteLabelButton : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{DeleteLabel();});
	}

	public static void DeleteLabel ()
	{
		int IdPRP = GlobalController.instance.prp.idRotuloPaciente;

		PontosRotuloPaciente.DeleteValue (IdPRP);
		DestroyInstance.DestroyGameObject();
	}
}
