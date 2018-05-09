using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using cryptpw;

using fisioterapeuta;


/**
 * Cria um novo Fisioterapeuta no banco de dados.
 */
public class Login : MonoBehaviour 
{

	public InputField login;
	public InputField pass;

	/**
 	 * Salva o Fisioterapeuta no banco.
 	 */
	public void Flow()
	{
		Fisioterapeuta idcheck = CheckLoginPass();

        if (idcheck != null) 
		{
			ColorBlock cb = pass.colors;
			cb.normalColor = ColorManager.success;
			login.colors = cb;
			pass.colors = cb;

			GlobalController.instance.admin = idcheck;

			SceneManager.LoadScene("Menu");
		} 
		else 
		{
			print("A combinação login+senha está incorreta!");
			ColorBlock cb = pass.colors;
			cb.normalColor = ColorManager.wrongConfirmation;
			login.colors = cb;
			pass.colors = cb;
		}
	}

	Fisioterapeuta CheckLoginPass () 
	
	{
		List<Fisioterapeuta> physiotherapists = Fisioterapeuta.Read();

		foreach (var fisio in physiotherapists) 
		{			
			if (fisio.login == login.text && 
				CryptPassword.Uncrypt(pass.text, fisio.senha, login.text))
           
{
				return fisio;
			}
		}

		return null;
	}
}
