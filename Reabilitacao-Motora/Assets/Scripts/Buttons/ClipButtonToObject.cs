using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClipButtonToObject : MonoBehaviour {

	public Button objectButton;
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
		objectButton.transform.position = pos;
	}
}
