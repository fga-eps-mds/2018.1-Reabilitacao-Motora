using UnityEngine;
using UnityEngine.UI;

public class Graphs2Bt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticGraphs2();});
	}
}