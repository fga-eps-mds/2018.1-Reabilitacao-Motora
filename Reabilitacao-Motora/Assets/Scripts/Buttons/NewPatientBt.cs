using UnityEngine;
using UnityEngine.UI;

public class NewPatientBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticNewPatient();});
	}
}