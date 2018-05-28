using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
