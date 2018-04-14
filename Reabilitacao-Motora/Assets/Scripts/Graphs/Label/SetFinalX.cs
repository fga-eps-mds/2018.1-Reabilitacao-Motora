using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Dita a posição final no eixo x da barra de rótulo.
 */
public class SetFinalX : MonoBehaviour
{
	public Label prefab;

	/**
	 * Cria a barra vertical para plotagem no gráfico e rotulação.
	 */
	void Update()
	{
		transform.localPosition = new Vector3 (prefab.FinalX, 3.75f, 0);
	}
}
