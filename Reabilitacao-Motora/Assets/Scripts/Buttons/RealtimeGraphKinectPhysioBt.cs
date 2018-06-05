using UnityEngine;
using UnityEngine.UI;

public class RealtimeGraphKinectPhysioBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticRealtimeGraphKinectPhysio();});
	}
}