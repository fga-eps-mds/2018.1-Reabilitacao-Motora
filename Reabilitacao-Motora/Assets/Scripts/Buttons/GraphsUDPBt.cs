using UnityEngine;
using UnityEngine.UI;

public class GraphsUDPBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		if(GlobalController.Sensor == false)
		{
			if (GlobalController.patientOrPhysio)
			{
				nextPage.onClick.AddListener(delegate{Flow.StaticRealtimeGraphKinectPhysio();});
			}
			else
			{
				nextPage.onClick.AddListener(delegate{Flow.StaticRealtimeGraphKinectPatient();});
			}
		}
		else
		{
			if (GlobalController.patientOrPhysio)
			{
				nextPage.onClick.AddListener(delegate{Flow.StaticRealtimeGraphUDPPhysio();});
			}
			else
			{
				nextPage.onClick.AddListener(delegate{Flow.StaticRealtimeGraphUDPPatient();});
			}
		}
	}
}