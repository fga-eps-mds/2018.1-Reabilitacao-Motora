using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using musculo;
using movimentomusculo;
using movimento;

/**
 * Cria um novo paciente no banco de dados.
 */
public class createMovement : MonoBehaviour
{
	[SerializeField]
	protected InputField nomeMovimento, musculos, descricao;
	/**
	 * Salva o Movimento no banco.
	 */
	public void saveMovement()
	{
		List<InputField> allInputs = new List<InputField>();

		allInputs.Add(nomeMovimento);
		allInputs.Add(musculos);
		allInputs.Add(descricao);

		if (ValidInput (allInputs))
		{
			foreach (var x in allInputs)
				ApplyColor (x, true);

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
		Flow.StaticClinic();
	}
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

	private static bool ValidInput (List<InputField> inputs)
	{
		bool valid = true;

		string treatName = TreatFields.NameField (inputs[0].text);
		string treatMusculo = TreatFields.EmptyField (inputs[1].text);

		string treatDescricao = "";
		if (inputs[2].text != "")
		{
			treatDescricao = TreatFields.EmptyField(inputs[2].text);
		}
		if (treatName != "" || treatMusculo != "" || treatDescricao != "")
		{
			if (treatName != "")
			{
				var splitBar = treatName.Split('|');
				foreach (var erro in splitBar)
				{
					print (erro);
				}

				ApplyColor (inputs[0], false);
			}
			if (treatMusculo != "")
			{
				var splitBar = treatMusculo.Split('|');
				foreach (var erro in splitBar)
				{
					print (erro);
				}

				ApplyColor (inputs[1], false);
			}
			if (treatDescricao != "")
			{
				var splitBar = treatDescricao.Split('|');
				foreach (var erro in splitBar)
				{
					print (erro);
				}

				ApplyColor (inputs[2], false);
			}
			valid = false;
		}

		return valid;
	}

	private static void ApplyColor (InputField input, bool ok)
	{
		input.colors = ColorManager.SetColor(input.colors, ok);
	}
}
