using UnityEngine;
using UnityEngine.UI;

public class MovementsToReviewBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticMovementsToReview();});
	}
}