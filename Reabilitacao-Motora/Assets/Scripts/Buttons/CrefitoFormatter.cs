using UnityEngine;
using UnityEngine.UI;

public class CrefitoFormatter : MonoBehaviour 
{
	[SerializeField]
	protected InputField crefito;

	public void Awake ()
	{
		crefito.characterLimit = 2;
	}

	public void Update ()
	{
		if (crefito.text.Length == 1)
		{
			crefito.text += " ";
			crefito.caretPosition = crefito.text.Length + 1;
		}
	}
}
