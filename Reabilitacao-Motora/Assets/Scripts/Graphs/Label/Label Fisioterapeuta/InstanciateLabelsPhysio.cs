using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using pontosrotulofisioterapeuta;

public class InstanciateLabelsPhysio : MonoBehaviour 
{
	[SerializeField]
	protected GameObject labelPrefab;


	void ButtonSpawner(PontosRotuloFisioterapeuta prf)
	{
		GameObject go = Instantiate(labelPrefab, transform);

		var aux = go.GetComponentInChildren<SetLabelPhysio>();
		aux.Prf = prf;

		var scriptInitial = go.GetComponentInChildren<SetInitialX>();
		var scriptFinal = go.GetComponentInChildren<SetFinalX>();
		var labelName = go.GetComponentInChildren<TextMesh>();

		scriptInitial.InitialX = prf.tempoInicial;
		scriptFinal.FinalX = prf.tempoFinal;

		scriptInitial.Set();
		scriptFinal.Set();

		labelName.text = prf.estagioMovimentoFisio;
	}

	public void Awake ()
	{
		if (GlobalController.instance.movement != null)
		{
			List<PontosRotuloFisioterapeuta> prfs = PontosRotuloFisioterapeuta.Read();
			foreach (var prf in prfs)
			{
				if (prf.idMovimento == GlobalController.instance.movement.idMovimento)
				{
					ButtonSpawner(prf);
				}
			}
		}
	}
}
