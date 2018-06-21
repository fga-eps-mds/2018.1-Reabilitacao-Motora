using UnityEngine;
using UnityEngine.UI;

public class MovementsMesmoBt : MonoBehaviour
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticMovements();});
	}
}
