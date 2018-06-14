using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using sessao;

public class instanciateSession : MonoBehaviour 
{
	[SerializeField]
	protected GameObject buttonPrefab;

	const int HEIGHT_PADDING = 55;

	public void ButtonSpawner(int posY, Sessao session)
	{
		GameObject go = Instantiate(buttonPrefab, transform);

		go.transform.position = new Vector3 (go.transform.position.x, go.transform.position.y - posY, go.transform.position.z);
		var aux = go.GetComponentInChildren<SetSessionToButton>();
		aux.Session = session;

		var temp = go.GetComponentInChildren<Text>();
		temp.text = formatName (session.dataSessao, session.observacaoSessao);
	}

	public void Awake ()
	{
		if (GlobalController.instance.user != null)
		{
			string query = string.Format("select * from SESSAO where idPaciente = {0}", GlobalController.instance.user.idPaciente);
			List<Sessao> sessions = Sessao.MultiSpecificSelect(query);
			int heightOffset = 10;

			foreach (var session in sessions)
			{
				ButtonSpawner(heightOffset, session);
				heightOffset += HEIGHT_PADDING;
			}
		}
	}

	public static string formatName (string dataSessao, string observacaoSessao)
	{
		var partsBetweenDashs = dataSessao.Split('-');
		var result = string.Format("{0}:{1} - {2}/{3}/{4}. Obs: {5}", partsBetweenDashs[3], partsBetweenDashs[4], partsBetweenDashs[2], partsBetweenDashs[1], partsBetweenDashs[0], observacaoSessao); 
		return result;
	}
}
