using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Descrever aqui o que essa classe realiza.
 */
public class SetFinalX : MonoBehaviour
{
	private float FinalX;
	public float finalX
	{
		get
		{
			return FinalX;
		}
		set
		{
			FinalX = value;
		}
	}

	/**
	 * Descrever aqui o que esse método realiza.
	 */
	public void Set()
	{
		transform.localPosition = new Vector3 (finalX, 3.75f, 0);
	}
}
