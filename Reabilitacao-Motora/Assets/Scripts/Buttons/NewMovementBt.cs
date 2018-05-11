using UnityEngine;
using UnityEngine.UI;

public class NewMovementBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticNewMovement();});
	}
}