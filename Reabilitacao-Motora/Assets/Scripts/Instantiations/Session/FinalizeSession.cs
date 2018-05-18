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
public class FinalizeSession : MonoBehaviour 
{
	public InputField observacaoSessao;

	/**
	 * Salva o paciente no banco.
	 */
	public void finalizeSessao()
	{
		
		Sessao.Update (GlobalController.instance.session.idSessao, 
			GlobalController.instance.admin.idFisioterapeuta, 
			GlobalController.instance.user.idPaciente, 
			GlobalController.instance.session.dataSessao,
			observacaoSessao.text);

		Flow.StaticNewSession();
	}
}
