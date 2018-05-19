using UnityEngine;
using UnityEngine.UI;

public class DateOfBirthFormatter : MonoBehaviour 
{
	[SerializeField]
	protected InputField date;

	public void Update ()
	{
		if (date.text.Length == 2 || date.text.Length == 5)
		{
			date.text += "/";
			date.caretPosition = date.text.Length + 1;
		}
	}
}
