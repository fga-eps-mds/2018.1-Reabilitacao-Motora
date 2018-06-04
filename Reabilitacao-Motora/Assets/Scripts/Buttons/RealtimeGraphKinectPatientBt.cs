using UnityEngine;
using UnityEngine.UI;

public class RealtimeGraphKinectPatientBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticRealtimeGraphKinectPatient();});
	}
}