using UnityEngine;
using UnityEngine.UI;

public class SessionsBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticPatient(); });
	}
}