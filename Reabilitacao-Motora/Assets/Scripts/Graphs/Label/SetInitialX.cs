using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Descrever aqui o que essa classe realiza.
 */
public class SetInitialX : MonoBehaviour
{
	private float initialX;
	public float InitialX
	{
		get
		{
			return initialX;
		}
		set
		{
			initialX = value;
		}
	}

	/**
	 * Descrever aqui o que esse método realiza.
	 */
	public void Set()
	{
		transform.localPosition = new Vector3 (InitialX, 3.75f, 0);
	}
}
