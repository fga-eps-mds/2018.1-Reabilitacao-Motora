using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	private float timer = 0;
	bool started = false;

	[SerializeField]
	protected GameObject textPrefab;

	public void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			started = !started;
			textPrefab.SetActive(!started);
		}

		if (started == true)
		{
			timer += Time.deltaTime;

			if (timer >= 15)
			{
				timer = 15;
			}
		}
	}

	public void OnGUI ()
	{
		GUI.Box(new Rect(10, 10, 50, 20), "" + timer.ToString("0"));
	}
}
