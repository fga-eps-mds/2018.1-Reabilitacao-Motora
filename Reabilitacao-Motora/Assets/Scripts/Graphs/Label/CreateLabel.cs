using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

/**
 * Cria o rótulo para a rotulação dos movimentos no gráfico.
 */
public class CreateLabel : MonoBehaviour
{
	public Label labelPrefab;
	public string[] labels;
	public Vector2[] vals;

	float chartHeight;

	/**
	 * Mostra o rótulo quando inicia a scene do gráfico.
	 */
	void Start()
	{
		displaygraph();
	}

	/**
	 * Caracteriza o rótulo usando as barras que o delimitam.
	 */
	void displaygraph()
	{
		for (int i = 0; i < vals.Length; ++i)
		{
			Label newLabel = Instantiate (labelPrefab) as Label;
			newLabel.transform.localPosition = new Vector3 (0f, 0f, 0f);
			newLabel.transform.SetParent (transform, false);
			newLabel.InitialX = vals[i].x;
			newLabel.FinalX= vals[i].y;
			newLabel.Description.text = labels[i];
		}
	}
}
