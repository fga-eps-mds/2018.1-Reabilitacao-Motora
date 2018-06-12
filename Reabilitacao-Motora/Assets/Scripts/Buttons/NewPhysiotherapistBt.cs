using UnityEngine;
using UnityEngine.UI;

public class NewPhysiotherapistBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		if (GlobalController.superAdm)
		{
			nextPage.onClick.AddListener(delegate{Flow.StaticNewPhysiotherapistAdm();});
		}
		else
		{
			nextPage.onClick.AddListener(delegate{Flow.StaticNewPhysiotherapistCommon();});
		}
	}
}