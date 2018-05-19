using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class padTrashCan : MonoBehaviour 
{
	// Update is called once per frame
	private void Update () 
	{
		var DescriptionLength = transform.parent.parent.GetComponentInChildren<TextMesh>().text.Length;
		transform.localPosition = new Vector3 (DescriptionLength + 1.5f, transform.localPosition.y, transform.localPosition.z);
	}
}
