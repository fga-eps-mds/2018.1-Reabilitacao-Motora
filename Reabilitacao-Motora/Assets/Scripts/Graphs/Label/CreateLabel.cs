using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

/**
 * Descrever aqui o que essa classe realiza.
 */
public class CreateLabel : MonoBehaviour
{
	public Label labelPrefab;
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
