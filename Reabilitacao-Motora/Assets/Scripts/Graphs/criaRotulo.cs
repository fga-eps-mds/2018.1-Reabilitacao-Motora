using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

/**
 * Descrever aqui o que essa classe realiza.
 */
public class criaRotulo : MonoBehaviour
	{
	public rotulo rotuloPrefab;
	public string[] labels;
	public Vector2[] vals;

	float chartHeight;

	/**
	 * Descrever aqui o que esse método realiza.
	 */
	void Start()
	{
		displaygraph();
	}

	/**
	 * Descrever aqui o que esse método realiza.
	 */
	void displaygraph()
	{
		for (int i = 0; i < vals.Length; ++i) {
			rotulo newRotulo = Instantiate (rotuloPrefab) as rotulo;
			newRotulo.transform.localPosition = new Vector3 (0f, 0f, 0f);
			newRotulo.transform.SetParent (transform, false);
			newRotulo.xInicial = vals[i].x;
			newRotulo.xFinal= vals[i].y;
			newRotulo.descricao.text = labels[i];
		}
	}
}
