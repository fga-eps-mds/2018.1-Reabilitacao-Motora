using UnityEngine;
using UnityEngine.UI;

public class DateOfBirthFormatter : MonoBehaviour 
{
	[SerializeField]
	protected InputField date;

	public void Awake ()
	{
		date.characterLimit = 10;
	}

	public void Start()
	{
		date.onValidateInput += delegate(string input, int charIndex, char addedChar) { return MyValidate(addedChar); };
	}

	private char MyValidate(char charToValidate)
	{
		if ((date.text.Length == 2 && charToValidate-'0' > 1)
		|| (date.text.Length == 0 && charToValidate-'0' > 3))
		{
			date.text += 0;
			date.caretPosition++;
			return charToValidate;
		}

		if ((date.text.Length == 1 && date.text[0]-'0' == 3 && charToValidate-'0' > 1)
		|| (date.text.Length == 1 && date.text[0]-'0' == 0 && charToValidate-'0' == 0)
		|| (date.text.Length == 3 && date.text[2]-'0' == 1 && charToValidate-'0' > 2)
		|| (date.text.Length == 4 && charToValidate-'0' > 1)
		|| (date.text.Length == 5 && charToValidate-'0' < 9)
		|| (date.text.Length == 6 && charToValidate-'0' < 2))
		{
			charToValidate = '\0';
			return charToValidate;
		}

		return charToValidate;
	}
}
