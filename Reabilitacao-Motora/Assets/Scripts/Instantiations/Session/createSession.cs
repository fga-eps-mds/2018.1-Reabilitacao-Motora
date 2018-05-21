using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

using sessao;


/**
 * Cria uma nova sessão no banco de dados.
 */
public class createSession : MonoBehaviour
{
	[SerializeField]
	protected Button nextPage;

	public void Awake ()
	{
		nextPage.onClick.AddListener(delegate{CreateSessao();});
	}

	/**
	 * Salva a sessão no banco.
	 */
	public static void CreateSessao()
	{

		string date = DateTime.Now.ToString("yyyy-MM-dd-HH-mm", System.Globalization.DateTimeFormatInfo.InvariantInfo);

		Sessao.Insert (GlobalController.instance.admin.idFisioterapeuta,
			GlobalController.instance.user.idPaciente, date, "");

		string namePatientUnderscored = (GlobalController.instance.user.persona.nomePessoa).Replace(' ', '_');
		string pathNameSession = "Assets\\Exercicios\\" + string.Format("{0}-{1}", GlobalController.instance.user.persona.idPessoa, namePatientUnderscored) + "\\" + date;
		Directory.CreateDirectory(pathNameSession);

		List<Sessao> sessions = Sessao.Read();

		GlobalController.instance.session = sessions[sessions.Count - 1];

		Flow.StaticNewSession();
	}
}
