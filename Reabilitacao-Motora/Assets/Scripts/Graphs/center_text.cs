using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Descrever aqui o que essa classe realiza.
 */
public class center_text : MonoBehaviour
	{
	public Transform line1, line2;

	/**
	 * Descrever aqui o que esse método realiza.
	 */
	void Start()
	{

	}

	/**
	 * Descrever aqui o que esse método realiza.
	 */
	void Update()
	{
		float x = (line1.position.x + line2.position.x) / 2f;
		float y = transform.position.y;
		float z = transform.position.z;
		transform.position = new Vector3 (x, y, z);
	}
}
