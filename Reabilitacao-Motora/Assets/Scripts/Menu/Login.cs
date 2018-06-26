using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using pessoa;
using cryptpw;

using fisioterapeuta;


/**
 * Cria um novo Fisioterapeuta no banco de dados.
 */
public class Login : MonoBehaviour 
{
	[SerializeField]
	protected InputField login, pass;

	[SerializeField]
	protected Button nextPage;

	[SerializeField]
	protected GameObject helpPopUp;

	bool first;
	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{Enter();});
		first = true;
	}
	/**
	 * Salva o Fisioterapeuta no banco.
	 */
	public void Enter()
	{
		Fisioterapeuta idcheck = CheckLoginPass();

		if (idcheck != null) 
		{
			GlobalController.instance.admin = idcheck;
			
			if (first)
			{
				GlobalController.superAdm = true;
			}
			
			Flow.StaticMenu();
		} 
		else 
		{
			ApplyColor (login, 0);
			ApplyColor (pass, 0);

			helpPopUp.SetActive(true);
		}
	}

	public static void ApplyColor (InputField input, int ok)
	{
		input.colors = ColorManager.SetColor(input.colors, ok);
	}

	Fisioterapeuta CheckLoginPass ()
	{
		List<Fisioterapeuta> physiotherapists = Fisioterapeuta.Read();
		foreach (var fisio in physiotherapists) 
		{			
			if (fisio.login == login.text && 
				CryptPassword.Uncrypt(pass.text, fisio.senha, login.text))
			{
				ApplyColor (login, 1);
				ApplyColor (pass, 1);
				return fisio;
			}
			first = false;
		}

		return null;
	}
}
