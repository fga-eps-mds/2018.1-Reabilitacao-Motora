using UnityEngine;
using UnityEngine.UI;

public class Graphs3Bt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticGraphs3();});
	}
}