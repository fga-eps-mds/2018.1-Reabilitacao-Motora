using UnityEngine;
using UnityEngine.UI;

public class MovementsBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticMovements();});
	}
}