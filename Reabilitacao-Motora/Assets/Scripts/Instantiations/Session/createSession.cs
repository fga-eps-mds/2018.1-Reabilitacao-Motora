using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

using sessao;


/**
 * Cria um novo paciente no banco de dados.
 */
public class createSession : MonoBehaviour 
{
	/**
 	 * Salva o paciente no banco.
 	 */
	public void CreateSessao()
	{

		string date = DateTime.Now.ToString("yyyy-MM-dd-HH-mm", System.Globalization.DateTimeFormatInfo.InvariantInfo);
		
		Sessao.Insert (GlobalController.instance.admin.idFisioterapeuta, 
			GlobalController.instance.user.idPaciente, date);

		string namePatientUnderscored = (GlobalController.instance.user.persona.nomePessoa).Replace(' ', '_');
		string pathNameSession = "Assets\\Exercicios\\" + string.Format("{0}-{1}", GlobalController.instance.user.persona.idPessoa, namePatientUnderscored) + "\\" + date;
		Directory.CreateDirectory(pathNameSession);

		List<Sessao> sessions = Sessao.Read();

		GlobalController.instance.session = sessions[sessions.Count - 1];

		Flow.StaticNewSession();
	}
}
