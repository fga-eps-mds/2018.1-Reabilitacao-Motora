using UnityEngine;
using UnityEngine.UI;

public class GraphsUDPBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		if(GlobalController.Sensor == true)
		{
			nextPage.onClick.AddListener(delegate{Flow.StaticRealtimeGraph2();});
		}
		else
		{
			nextPage.onClick.AddListener(delegate{Flow.StaticRealtimeGraph1();});
		}
	}
}