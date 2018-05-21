using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Descrever aqui o que essa classe realiza.
 */
public class SetFinalX : MonoBehaviour
{
	private float finalX;
	public float FinalX
	{
		get
		{
			return finalX;
		}
		set
		{
			finalX = value;
		}
	}

	/**
	 * Descrever aqui o que esse método realiza.
	 */
	public void Set()
	{
		transform.localPosition = new Vector3 (FinalX, 3.75f, 0);
	}
}
