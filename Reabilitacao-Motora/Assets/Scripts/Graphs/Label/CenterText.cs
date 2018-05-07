using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Classe responsável por manipular texto referente às labels.
 */
public class CenterText : MonoBehaviour
{
	public Transform line1, line2;

	/**
	 * Centraliza o nome da label de acordo com o X inicial e X final.
	 */
	void Update()
	{
		float x = (line1.position.x + line2.position.x) / 2f;
		float y = transform.position.y;
		float z = transform.position.z;
		transform.position = new Vector3 (x, y, z);
	}
}
