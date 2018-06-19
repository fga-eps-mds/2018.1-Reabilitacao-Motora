using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using pontosrotulopaciente;

/**
 * Descrever aqui o que essa classe realiza.
 */
public class CreateLabelPatient : MonoBehaviour
{
	[SerializeField]
	protected GameObject labelPrefab;
	
	string nameLabel = "Descrição do Rótulo";
	string initialX = "x inicial", finalX = "x final";

	/**
	 * Descrever aqui o que esse método realiza.
	 */
	public void displayGraph(string label, Vector2 val)
	{
		GameObject go = Instantiate (labelPrefab) as GameObject;

		go.transform.localPosition = new Vector3 (0f, 0f, 0f);
		go.transform.SetParent (transform, false);

		var scriptInitial = go.GetComponentInChildren<SetInitialX>();
		var scriptFinal = go.GetComponentInChildren<SetFinalX>();
		var labelName = go.GetComponentInChildren<TextMesh>();
		var dbPrpObject = go.GetComponentInChildren<SetLabelPatient>();

		scriptInitial.InitialX = val.x;
		scriptFinal.FinalX = val.y;

		scriptInitial.Set();
		scriptFinal.Set();

		labelName.text = label;

		PontosRotuloPaciente.Insert(GlobalController.instance.exercise.idExercicio, label, val.x, val.y);
		List<PontosRotuloPaciente> allPrp = PontosRotuloPaciente.Read();

		dbPrpObject.Prp = allPrp[allPrp.Count - 1];
	}


	public void OnGUI()
	{
		GUI.Box(new Rect (3 * (Screen.width/5), 7.4f * (Screen.height/9), Screen.width/4, 60),""); 

		GUILayout.BeginArea(new Rect(3 * (Screen.width/5), 7.5f * (Screen.height/9), Screen.width/4, 50));
			GUILayout.BeginHorizontal();
				nameLabel = GUILayout.TextField(nameLabel, GUILayout.Width(120));
				initialX = GUILayout.TextField(initialX, GUILayout.Width(90));
				finalX = GUILayout.TextField(finalX, GUILayout.Width(90));
				initialX = System.Text.RegularExpressions.Regex.Replace(initialX, "[^0-9.,]", "");
				finalX = System.Text.RegularExpressions.Regex.Replace(finalX, "[^0-9.,]", "");
			GUILayout.EndHorizontal();

			if (GUILayout.Button("Salvar")) 
			{
				string label = nameLabel;
				initialX = initialX.Replace(',', '.');
				finalX = finalX.Replace(',', '.');
				Vector2 val = new Vector2 (float.Parse(initialX), float.Parse(finalX));

				if (Mathf.Abs(val.x - val.y) > 0.4)
				{
					displayGraph (label, val);
				}
				else
				{
					Debug.Log("Há de se ter alguma distancia entre os pontos!");
				}
			}

		GUILayout.EndArea();
	}
}
