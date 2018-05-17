
using System.Collections;
using UnityEngine;
using pontosrotulopaciente;
 
class MoveObjectXAxis : MonoBehaviour
{
	private bool dragging;
	private float distance;
 
   
	public void OnMouseDown()
	{
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		dragging = true;
	}
 
	public void OnMouseUp()
	{
		dragging = false;
		
		var currentObjectName = transform.name;
		var desc = transform.parent.gameObject.GetComponentInChildren<SetLabel>();
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
			transform.position = new Vector3 (rayPoint.x, transform.position.y, transform.position.z);
		}
	}
}