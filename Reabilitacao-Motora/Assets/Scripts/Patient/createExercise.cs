using System;
using System.Linq;
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
public class createExercise : MonoBehaviour 
{
	public InputField nomeMovimento;
	public InputField musculos;
	public InputField descricao;


	/**
 	 * Salva o paciente no banco.
 	 */
	public void saveExercise()
	{

		var muscles = musculos.text.Split(',');

		string movunderscored = (nomeMovimento.text).Replace(' ', '_');
		string physiounderscored = (GlobalController.instance.admin.persona.nomePessoa).Replace(' ', '_');

		string pathSave = GlobalController.instance.admin.idPessoa + "-";

		pathSave += physiounderscored + "/";
		pathSave += movunderscored + "-";
		pathSave += DateTime.Now.ToString("HHmmss", System.Globalization.DateTimeFormatInfo.InvariantInfo);
		
		Movimento.Insert (GlobalController.instance.admin.idFisioterapeuta, 
							nomeMovimento.text, descricao.text, pathSave);

		List<Movimento> movementsList = Movimento.Read();

		foreach (var muscle in muscles) 
		{
			name = new string((from c in muscle where char.IsLetterOrDigit(c) select c).ToArray());
			if (!checkMuscle(name)) 
			{
				Musculo.Insert(name);
				List<Musculo> musclesList = Musculo.Read();
				MovimentoMusculo.Insert(musclesList[musclesList.Count - 1].idMusculo, movementsList[movementsList.Count - 1].idMovimento);
			}
		}

		GlobalController.instance.movement = movementsList[movementsList.Count - 1];
		SceneManager.LoadScene("Clinic");
	}

	static bool checkMuscle (string name)
	{
		List<Musculo> musclesList = Musculo.Read();

		foreach (var muscle in musclesList)
		{
			if(muscle.nomeMusculo == name)
			{
				return true;
			}
		}

		return false;
	}
}