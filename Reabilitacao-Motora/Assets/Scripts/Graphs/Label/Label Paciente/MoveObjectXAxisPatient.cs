using System.Collections;
using UnityEngine;
using pontosrotulopaciente;
 
class MoveObjectXAxisPatient : MonoBehaviour
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
		var desc = transform.parent.gameObject.GetComponentInChildren<SetLabelPatient>();
		int index = transform.GetSiblingIndex();

		if (currentObjectName == "xInicial")
		{
			var brotherX = transform.parent.GetChild(index + 1).gameObject.transform.localPosition.x;
			PontosRotuloPaciente.Update(desc.Prp.idRotuloPaciente, GlobalController.instance.exercise.idExercicio, desc.Prp.estagioMovimentoPaciente, transform.localPosition.x, brotherX);
		}
		
		if (currentObjectName == "xFinal")
		{
			var brotherX = transform.parent.GetChild(index - 1).gameObject.transform.localPosition.x;
			PontosRotuloPaciente.Update(desc.Prp.idRotuloPaciente, GlobalController.instance.exercise.idExercicio, desc.Prp.estagioMovimentoPaciente, brotherX, transform.localPosition.x);
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