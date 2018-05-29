using UnityEngine;
using UnityEngine.UI;

public class RealtimeBackBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		if(GlobalController.patientOrPhysio == true)
		{
			nextPage.onClick.AddListener(delegate{Flow.StaticMovements();});
		}
		else
		{
			nextPage.onClick.AddListener(delegate{Flow.StaticNewSession();});
		}
	}
}