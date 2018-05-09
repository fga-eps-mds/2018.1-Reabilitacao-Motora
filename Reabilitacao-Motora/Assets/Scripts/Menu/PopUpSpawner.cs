﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Instancia um PopUp quando clica em um determinado botão.
 */

public class PopUpSpawner : MonoBehaviour
{

    private GameObject popUpPrefab;
    public GameObject PopUpPrefab
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

	/**
 	 * Deixa a instancia do Prefab do popUp ativa.
 	 */
    public void Spawner()
    {
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
