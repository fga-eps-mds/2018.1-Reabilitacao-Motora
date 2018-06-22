using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using fisioterapeuta;

public class instanciatePhysiotherapist : MonoBehaviour 
{
	[SerializeField]
	protected GameObject buttonPrefab;

	const int HEIGHT_PADDING = 55;

	public void ButtonSpawner(int posY, Fisioterapeuta physiotherapist)
	{
		GameObject go = Instantiate(buttonPrefab, transform);

		go.transform.position = new Vector3 (go.transform.position.x + 20, go.transform.position.y - posY, go.transform.position.z);
		
		var script = go.GetComponentInChildren<SetPhysiotherapistToButton>();
		script.Physiotherapist = physiotherapist;

		var temp = go.GetComponentInChildren<Text>();
		temp.text = formatName(physiotherapist.persona.nomePessoa, physiotherapist.crefito, physiotherapist.persona.telefone1);
	}

	public void Awake ()
	{
		List<Fisioterapeuta> physiotherapists = Fisioterapeuta.Read();

		int heightOffset = 0;

		foreach (var physiotherapist in physiotherapists)
		{
			ButtonSpawner(heightOffset, physiotherapist);
			heightOffset += HEIGHT_PADDING;
		}

	}

    public static string formatName(string nomePessoa, string crefito, string telefone1)
    {
        //var partsBetweenDashs = .Split('-');
        var result = string.Format("{0}. {1}. {2}", nomePessoa, crefito, telefone1);
        return result;
    }
}
