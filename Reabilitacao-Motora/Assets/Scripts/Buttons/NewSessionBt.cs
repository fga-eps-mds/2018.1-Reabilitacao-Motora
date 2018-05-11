using UnityEngine;
using UnityEngine.UI;

public class NewSessionBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticNewSession();});
	}
}