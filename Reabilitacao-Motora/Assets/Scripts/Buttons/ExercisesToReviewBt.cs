using UnityEngine;
using UnityEngine.UI;

public class ExercisesToReviewBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticExercisesToReview();});
	}
}