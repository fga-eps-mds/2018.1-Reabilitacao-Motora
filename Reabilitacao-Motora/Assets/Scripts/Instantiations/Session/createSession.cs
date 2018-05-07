using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using sessao;


/**
 * Cria um novo paciente no banco de dados.
 */
public class createSessao : MonoBehaviour 
{
	/**
 	 * Salva o paciente no banco.
 	 */
	public void CreateSessao()
	{

		string date = DateTime.Now.ToString("yyyy-MM-dd-HH", System.Globalization.DateTimeFormatInfo.InvariantInfo);
		
		Sessao.Insert (GlobalController.instance.admin.idFisioterapeuta, 
			GlobalController.instance.user.idPaciente, date);

		List<Sessao> sessions = Sessao.Read();

		GlobalController.instance.session = sessions[sessions.Count - 1];

		Flow.StaticNewSession();
	}
}