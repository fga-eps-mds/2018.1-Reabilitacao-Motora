using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using musculo;
using movimentomusculo;
using movimento;

/**
 * Cria um novo paciente no banco de dados.
 */
public class createMovement : MonoBehaviour 
{
	string path;
	Movimento tableMovimento;
	Musculo tableMusculo;
	MovimentoMusculo tableMM;

	public InputField nomeMovimento;
	public InputField musculos;
	public InputField descricao;

	/**
 	 * Salva o paciente no banco.
 	 */
	public void saveMovement()
	{
		path = "URI=file:" + Application.dataPath + "/Plugins/fisiotech.db";

		var trip = musculos.text.Split(',');

		tableMusculo = new Musculo(path);
		tableMM = new MovimentoMusculo(path);
		tableMovimento = new Movimento(path);

		string movunderscored = (nomeMovimento.text).Replace(' ', '_');
		string physiounderscored = (GlobalController.instance.admin.persona.nomePessoa).Replace(' ', '_');

		string pathSave = GlobalController.instance.admin.idPessoa + "-";
		pathSave += physiounderscored + "/";
		pathSave += movunderscored + "-";
		pathSave += DateTime.Now.ToString("HHmmss", System.Globalization.DateTimeFormatInfo.InvariantInfo);
		
		tableMovimento.Insert (GlobalController.instance.admin.idFisioterapeuta, 
							   nomeMovimento.text, descricao.text, pathSave);

		List<Movimento.Movimentos> aux = tableMovimento.Read();

		foreach (var tt in trip) {
			tableMusculo.Insert(tt);
			List<Musculo.Musculos> x = tableMusculo.Read();
			tableMM.Insert(x[x.Count - 1].idMusculo, aux[aux.Count - 1].idMovimento);
		}

		GlobalController.instance.movement = aux[aux.Count-1];
		SceneManager.LoadScene("Clinic");
	}
}
