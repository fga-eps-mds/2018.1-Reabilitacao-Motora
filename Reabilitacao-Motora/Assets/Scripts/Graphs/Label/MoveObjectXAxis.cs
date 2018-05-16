
using System.Collections;
using UnityEngine;
using pontosrotulopaciente;
 
class MoveObjectXAxis : MonoBehaviour
{
	private bool dragging = false;
	private float distance;
 
   
	void OnMouseDown()
	{
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		dragging = true;
	}
 
	void OnMouseUp()
	{
		dragging = false;
		
		var currentObjectName = transform.name;
		var label = transform.parent.gameObject.GetComponentInChildren<TextMesh>();
		int index = transform.GetSiblingIndex();

		if (currentObjectName == "xInicial")
		{
			var brotherX = transform.parent.GetChild(index + 1).gameObject.transform.localPosition.x;
			PontosRotuloPaciente.Update(GlobalController.instance.exercise.idExercicio, label, transform.localPosition.x, brotherX);
		}
		
		if (currentObjectName == "xFinal")
		{
			var brotherX = transform.parent.GetChild(index - 1).gameObject.transform.localPosition.x;
			PontosRotuloPaciente.Update(GlobalController.instance.exercise.idExercicio, label, brotherX, transform.localPosition.x);
		}
	}
 
	void Update()
	{
		if (dragging)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint(distance);
			transform.position = new Vector3 (rayPoint.x, transform.position.y, transform.position.z);
		}
	}
}