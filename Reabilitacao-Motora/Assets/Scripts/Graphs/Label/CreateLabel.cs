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
	[SerializeField]
	protected Label labelPrefab;
	
	string nameLabel = "label name";
	string initialX = "0", finalX = "0";

	/**
	 * Descrever aqui o que esse método realiza.
	 */
	void displayGraph(string label, Vector2 val)
	{
		Label newLabel = Instantiate (labelPrefab) as Label;

		newLabel.transform.localPosition = new Vector3 (0f, 0f, 0f);
		newLabel.transform.SetParent (transform, false);
		newLabel.InitialX = val.x;
		newLabel.FinalX= val.y;
		newLabel.Description.text = label;
	}


	void OnGUI()
	{
		GUI.Box(new Rect (3 * (Screen.width/5), 7.4f * (Screen.height/9), Screen.width/4, 60),""); 

		GUILayout.BeginArea(new Rect(3 * (Screen.width/5), 7.5f * (Screen.height/9), Screen.width/4, 50));
			GUILayout.BeginHorizontal();
				nameLabel = GUILayout.TextField(nameLabel, GUILayout.Width(120));
				initialX = GUILayout.TextField(initialX, GUILayout.Width(90));
				finalX = GUILayout.TextField(finalX, GUILayout.Width(90));
			GUILayout.EndHorizontal();

			if (GUILayout.Button("Apply to Chart")) 
			{
				string label = nameLabel;
				Vector2 val = new Vector2 (float.Parse(initialX), float.Parse(finalX));
				displayGraph (label, val);
			}

		GUILayout.EndArea();
	}
}
