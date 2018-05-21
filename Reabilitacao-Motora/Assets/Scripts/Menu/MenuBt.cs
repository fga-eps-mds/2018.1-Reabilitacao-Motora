using UnityEngine;
using UnityEngine.UI;

public class MenuBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticMenu();});
	}
}