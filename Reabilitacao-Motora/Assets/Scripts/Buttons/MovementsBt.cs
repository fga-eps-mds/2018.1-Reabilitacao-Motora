using UnityEngine;
using UnityEngine.UI;

public class MovementsBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		//nextPage.onClick.AddListener(delegate{Flow.StaticMovements();});
		nextPage.onClick.AddListener(delegate{Flow.StaticCharacterMenu();});

	}
}