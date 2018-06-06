using UnityEngine;
using UnityEngine.UI;

public class CharacterMenuBt : MonoBehaviour
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Flow.StaticCharacterMenu();});
	}
}
