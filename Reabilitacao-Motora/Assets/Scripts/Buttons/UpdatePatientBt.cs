using UnityEngine;
using UnityEngine.UI;

public class UpdatePatientBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticUpdatePatient();});
	}
}