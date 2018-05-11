using UnityEngine;
using UnityEngine.UI;

public class PatientBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticPatient();});
	}
}