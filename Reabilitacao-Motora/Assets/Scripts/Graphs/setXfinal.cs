using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setXfinal : MonoBehaviour {
	public rotulo prefab;

	void Update () {
		transform.localPosition = new Vector3 (prefab.xFinal, 3.75f, 0);
	}
}
