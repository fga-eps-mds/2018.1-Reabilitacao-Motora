using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class center_text : MonoBehaviour {
	public Transform line1, line2;
	// Use this for initialization

	void Start () {

	}

	void Update () {
		float x = (line1.position.x + line2.position.x) / 2f;
		float y = transform.position.y;
		float z = transform.position.z;
		transform.position = new Vector3 (x, y, z);
	}

}
