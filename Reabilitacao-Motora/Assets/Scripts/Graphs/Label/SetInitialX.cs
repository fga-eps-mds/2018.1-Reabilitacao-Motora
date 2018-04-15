﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Descrever aqui o que essa classe realiza.
 */
public class SetInitialX : MonoBehaviour
{
	public Label prefab;

	/**
	 * Descrever aqui o que esse método realiza.
	 */
	void Update()
	{
		transform.localPosition = new Vector3 (prefab.InitialX, 3.75f, 0);
	}
}
