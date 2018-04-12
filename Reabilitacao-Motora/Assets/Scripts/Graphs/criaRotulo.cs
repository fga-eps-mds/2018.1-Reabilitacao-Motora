using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class criaRotulo : MonoBehaviour {

	public rotulo rotuloPrefab;
	public string[] labels;
	public Vector2[] vals;

	float chartHeight;

	void Start () {
		displaygraph ();
	}

	void displaygraph () {
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