using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Descrever aqui o que essa classe realiza.
 */
public class setXinicial : MonoBehaviour
{
	public rotulo prefab;

	/**
	 * Descrever aqui o que esse método realiza.
	 */
	void Update()
	{
		transform.localPosition = new Vector3 (prefab.xInicial, 3.75f, 0);
	}
}
