using UnityEngine;
using UnityEngine.UI;

public class RealtimeGraph2Bt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticRealtimeGraph2();});
	}
}