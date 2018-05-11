using UnityEngine;
using UnityEngine.UI;

public class MovementsToExerciseBt : MonoBehaviour 
{
	[SerializeField]
	protected Button nextPage;

	void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticMovementsToExercise();});
	}
}