using System.Collections;
using UnityEngine;
using pontosrotulofisioterapeuta;
using pontosrotulopaciente;

class MoveObjectXAxis : MonoBehaviour
{
	private bool dragging;
	private float distance;
 
   	private Transform originGrafico;
   	private Transform endOfX;

   	private Vector3 auxOrigin;
   	private Vector3 auxEndX;

 	public void Start()
 	{
 		originGrafico = GameObject.Find("origin").transform;
 		endOfX = GameObject.Find("EndOfX").transform;

 		auxOrigin = originGrafico.position;

 		endOfX.localPosition = new Vector3 (endOfX.localPosition.x - 0.33f, endOfX.localPosition.y, endOfX.localPosition.z);
 		auxEndX = endOfX.position;
 		endOfX.localPosition = new Vector3 (endOfX.localPosition.x + 0.33f, endOfX.localPosition.y, endOfX.localPosition.z);
 	}

	public void OnMouseDown()
	{
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		dragging = true;
	}
 
	public void OnMouseUp()
	{
		dragging = false;
		
		var currentObjectName = transform.name;
		var suggaDeri = transform.parent.gameObject;
		var patientOrPhysio = transform.parent.name == "RotuloFisioterapeuta(Clone)";

		SetLabelPatient descPatient;
		if (patientOrPhysio == false)
		{
			descPatient = suggaDeri.GetComponentInChildren<SetLabelPatient>();
		}
		else
		{
			descPatient = null;
		}

		SetLabelPhysio descPhysio;
		if (patientOrPhysio == true)
		{
			descPhysio = suggaDeri.GetComponentInChildren<SetLabelPhysio>();
		}
		else
		{
			descPhysio = null;
		}

		int index = transform.GetSiblingIndex();

		if (currentObjectName == "xInicial")
		{
			var brotherX = transform.parent.GetChild(index + 1).gameObject.transform.localPosition.x;
			if (patientOrPhysio)
			{
				PontosRotuloFisioterapeuta.Update(descPhysio.Prf.idRotuloFisioterapeuta, GlobalController.instance.movement.idMovimento, descPhysio.Prf.estagioMovimentoFisio, transform.localPosition.x, brotherX);
			}
			else
			{
				PontosRotuloPaciente.Update(descPatient.Prp.idRotuloPaciente, GlobalController.instance.exercise.idExercicio, descPatient.Prp.estagioMovimentoPaciente, transform.localPosition.x, brotherX);
			}
		}
		
		if (currentObjectName == "xFinal")
		{
			var brotherX = transform.parent.GetChild(index - 1).gameObject.transform.localPosition.x;
			if (patientOrPhysio)
			{
				PontosRotuloFisioterapeuta.Update(descPhysio.Prf.idRotuloFisioterapeuta, GlobalController.instance.movement.idMovimento, descPhysio.Prf.estagioMovimentoFisio, brotherX, transform.localPosition.x);
			}
			else
			{
				PontosRotuloPaciente.Update(descPatient.Prp.idRotuloPaciente, GlobalController.instance.exercise.idExercicio, descPatient.Prp.estagioMovimentoPaciente, brotherX, transform.localPosition.x);
			}
		}
	}
 
	public void Update()
	{
		if (dragging)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint(distance);
			var x = Mathf.Max(rayPoint.x, auxOrigin.x);
			x = Mathf.Min(auxEndX.x, x);
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
		}
	}
}