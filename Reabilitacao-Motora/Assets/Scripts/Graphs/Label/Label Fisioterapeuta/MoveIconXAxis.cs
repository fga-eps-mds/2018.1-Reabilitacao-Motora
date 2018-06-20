using System.Collections;
using UnityEngine;
using pontosrotulofisioterapeuta;
using pontosrotulopaciente;

class MoveIconXAxis : MonoBehaviour
{
	private bool dragging;
	private float distance;
 
   	private Transform originGrafico;
   	private Transform endOfX;
   	private Vector3 auxOrigin;
   	private Vector3 auxEndX;
   	private SpriteRenderer icon;
 	public void Start()
 	{
 		originGrafico = GameObject.Find("origin").transform;
 		endOfX = GameObject.Find("EndOfX").transform;
 		icon = gameObject.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
 		auxOrigin = originGrafico.position;

 		endOfX.localPosition = new Vector3 (endOfX.localPosition.x - 0.33f, endOfX.localPosition.y, endOfX.localPosition.z);
 		auxEndX = endOfX.position;
 		endOfX.localPosition = new Vector3 (endOfX.localPosition.x + 0.33f, endOfX.localPosition.y, endOfX.localPosition.z);
 	}

	public void OnMouseDown()
	{
		dragging = true;
	}
 
	public void OnMouseUp()
	{
		dragging = false;
		
		var currentObjectName = transform.parent.name;
		var suggaDeri = transform.parent.parent.gameObject;
		var patientOrPhysio = transform.parent.parent.name == "RotuloFisioterapeuta";

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
		
		int index = transform.parent.GetSiblingIndex();
		Debug.Log(patientOrPhysio);
		if (currentObjectName == "xInicial")
		{
			Debug.Log(transform.parent.parent.GetChild(index + 1).gameObject.transform.name);
			var brotherX = transform.parent.parent.GetChild(index + 1).gameObject.transform.localPosition.x;
			if (patientOrPhysio)
			{
				PontosRotuloFisioterapeuta.Update(descPhysio.Prf.idRotuloFisioterapeuta, GlobalController.instance.movement.idMovimento, descPhysio.Prf.estagioMovimentoFisio, transform.parent.localPosition.x, brotherX);
			}
			else
			{
				PontosRotuloPaciente.Update(descPatient.Prp.idRotuloPaciente, GlobalController.instance.exercise.idExercicio, descPatient.Prp.estagioMovimentoPaciente, transform.parent.localPosition.x, brotherX);
			}
		}
		
		if (currentObjectName == "xFinal")
		{
			Debug.Log(transform.parent.parent.GetChild(index - 1).gameObject.transform.name);
			var brotherX = transform.parent.parent.GetChild(index - 1).gameObject.transform.localPosition.x;
			if (patientOrPhysio)
			{
				PontosRotuloFisioterapeuta.Update(descPhysio.Prf.idRotuloFisioterapeuta, GlobalController.instance.movement.idMovimento, descPhysio.Prf.estagioMovimentoFisio, brotherX, transform.parent.localPosition.x);
			}
			else
			{
				PontosRotuloPaciente.Update(descPatient.Prp.idRotuloPaciente, GlobalController.instance.exercise.idExercicio, descPatient.Prp.estagioMovimentoPaciente, brotherX, transform.parent.localPosition.x);
			}
		}
	}

	public void Update()
	{
		distance = Vector3.Distance(transform.parent.position, Camera.main.transform.position);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Vector3 rayPoint = ray.GetPoint(distance);
		var zz = Vector3.Distance(transform.parent.position, rayPoint);
		var dist = 1.8f - zz;
		if (dist <= 1.8f && dist >= 0)
		{
			icon.color = new Color(icon.color.r, icon.color.g, icon.color.b, dist/1.8f);
		}
		else if (dist > 1.8f)
		{
			icon.color = new Color(icon.color.r, icon.color.g, icon.color.b, 0);
		}

		if (dragging)
		{
			var x = Mathf.Max(rayPoint.x, auxOrigin.x);
			x = Mathf.Min(auxEndX.x, x);
			transform.parent.position = new Vector3 (x, transform.parent.position.y, transform.parent.position.z);
		}
	}
}