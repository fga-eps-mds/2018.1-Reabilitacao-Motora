using UnityEngine;
using UnityEngine.UI;

public class NewSessionBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticNewSession();});
	}
}