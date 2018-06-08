using UnityEngine;
using UnityEngine.UI;

public class QuitBt : MonoBehaviour
{
	[SerializeField]
	protected Button quit;

	public void Awake ()
	{
		quit.onClick.AddListener(delegate{Flow.StaticQuit();});
	}
}
