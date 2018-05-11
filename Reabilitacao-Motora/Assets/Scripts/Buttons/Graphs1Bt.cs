using UnityEngine;
using UnityEngine.UI;

public class Graphs1Bt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticGraphs1();});
	}
}