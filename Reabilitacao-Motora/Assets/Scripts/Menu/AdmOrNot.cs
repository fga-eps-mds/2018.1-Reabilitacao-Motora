using UnityEngine;

public class AdmOrNot : MonoBehaviour 
{
	[SerializeField]
	protected GameObject physioButton;

	public void Awake ()
	{
		if (GlobalController.superAdm)
		{
			physioButton.SetActive(true);
		}
	}
}