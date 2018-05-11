using UnityEngine;
using UnityEngine.UI;

public class ClinicBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticClinic();});
	}
}