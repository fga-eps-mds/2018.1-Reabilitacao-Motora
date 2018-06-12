using UnityEngine;
using UnityEngine.UI;

public class UpdatePhysiotherapistBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticUpdatePhysiotherapist();});
	}
}