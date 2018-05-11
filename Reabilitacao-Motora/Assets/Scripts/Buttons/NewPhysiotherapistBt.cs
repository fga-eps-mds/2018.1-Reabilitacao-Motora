using UnityEngine;
using UnityEngine.UI;

public class NewPhysiotherapistBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticNewPhysiotherapist();});
	}
}