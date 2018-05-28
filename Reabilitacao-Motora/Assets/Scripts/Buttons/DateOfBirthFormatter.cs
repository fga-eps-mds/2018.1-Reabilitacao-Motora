using UnityEngine;
using UnityEngine.UI;

public class DateOfBirthFormatter : MonoBehaviour 
{
	[SerializeField]
	protected InputField date;

	private int lastsize;

	public void Awake ()
	{
		date.characterLimit = 10;
		lastsize = 0;
	}

	public void Update ()
	{
		int count = 0;
		foreach (char c in date.text)
		{ 
			if (c == '/')
			{
				count++;
			}
		}

		// 01 2 34 5 6789
		// 10 / 10 / 1900

		if (count == 0 && date.text.Length == 2 && date.caretPosition == 2 && date.caretPosition > lastsize)
		{
			date.text += "/";
			date.caretPosition = date.text.Length + 1;
		}

		if (count == 1 && date.text.Length == 5 && date.caretPosition == 5 && date.caretPosition > lastsize)
		{
			date.text += "/";
			date.caretPosition = date.text.Length + 1;
		}

		if (count == 1 && date.text.Length == 3 && date.caretPosition == 3 && date.caretPosition < lastsize)
		{
			date.text.Remove(date.text.Length - 1, 1);
			date.caretPosition = date.text.Length - 1;
		}

		if (count == 2 && date.text.Length == 6 && date.caretPosition == 6 && date.caretPosition < lastsize)
		{
			date.text.Remove(date.text.Length - 1, 1);
			date.caretPosition = date.text.Length - 1;
		}

		lastsize = date.caretPosition;
	}
}
