using UnityEngine;
using UnityEngine.UI;

public class LoginBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticLogin();});
	}
}