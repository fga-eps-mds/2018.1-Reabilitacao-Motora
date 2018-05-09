using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Instancia um PopUp quando clica em um determinado botão.
 */

public class PopUpSpawner : MonoBehaviour
{
    public GameObject popUpPrefab;
    private GameObject PopUpPrefab
    {
        get
        {
            return popUpPrefab;
        }
        set
        {
            popUpPrefab = value;
        }
    }

    public GameObject canvas;
    private GameObject Canvas
    {
        get
        {
            return canvas;
        }
        set
        {
            canvas = value;
        }
    }

	/**
 	 * Deixa a instancia do Prefab do popUp ativa.
 	 */
    public void Spawner()
    {
        PopUpPrefab.transform.SetSiblingIndex(Canvas.transform.childCount - 1);
        PopUpPrefab.SetActive(true);
    }

	/**
 	 * Deixa a instancia do Prefab do popUp desativada.
 	 */
    public void Eraser()
    {
        PopUpPrefab.SetActive(false);
    }
}
