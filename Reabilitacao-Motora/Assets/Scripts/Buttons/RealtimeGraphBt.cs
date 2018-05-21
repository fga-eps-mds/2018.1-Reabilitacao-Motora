using UnityEngine;
using UnityEngine.UI;

public class RealtimeGraphBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticRealtimeGraph();});
	}
}