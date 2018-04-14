using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Centraliza o rótulo.
 */
public class CenterText : MonoBehaviour
	{
	public Transform line1, line2;

	/**
	 * Coloca o texto do rótulo no centro de duas barras.
	 */
	void Update()
	{
		float x = (line1.position.x + line2.position.x) / 2f;
		float y = transform.position.y;
		float z = transform.position.z;
		transform.position = new Vector3 (x, y, z);
	}
}
