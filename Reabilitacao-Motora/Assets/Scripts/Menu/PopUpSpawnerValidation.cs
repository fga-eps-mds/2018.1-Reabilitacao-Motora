using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Instancia um PopUp quando clica em um determinado botão.
 */

public class PopUpSpawnerValidation : MonoBehaviour
{
	[SerializeField]
	protected GameObject PopUpValidationPrefab, Canvas;

	/**
	 * Deixa a instancia do Prefab do popUp ativa.
	 */
	public void Spawner()
	{
		PopUpValidationPrefab.transform.SetSiblingIndex(Canvas.transform.childCount - 1);
		Text defaultText = PopUpValidationPrefab.GetComponentInChildren<Text>();
		defaultText.text = "Campos com * são OBRIGATÓRIOS\n\n- A data de nascimento deve ser real. Insira apenas números;\n- O número de telefone deve possuir mais de 8 digitos numéricos;\n- A sigla da região deve ser escrita em letra maiúscula;\n- CREFITO deve possuir exatamente 6 digitos numéricos;\n- Login do fisioterapeuta deve conter no minimo 6 digitos;\n- A senha do fisioterapeuta deve conter no minimo 8 digitos.";

		PopUpValidationPrefab.GetComponent<RectTransform>().offsetMin = new Vector2(
			-80, -150);
		PopUpValidationPrefab.GetComponent<RectTransform>().offsetMax = new Vector2(
			80, 150);
		PopUpValidationPrefab.SetActive(true);

	}

	/**
	 * Deixa a instancia do Prefab do popUp desativada.
	 */
	public void Eraser()
	{
		PopUpValidationPrefab.SetActive(false);
	}
}
