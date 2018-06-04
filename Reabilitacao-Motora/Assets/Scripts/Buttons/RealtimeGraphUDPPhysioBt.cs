using UnityEngine;
using UnityEngine.UI;

public class RealtimeGraphUDPPhysioBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticRealtimeGraphUDPPhysio();});
	}
}