using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setXinicial : MonoBehaviour {
	public rotulo prefab;

	void Update () {
		transform.localPosition = new Vector3 (prefab.xInicial, 3.75f, 0);
	}
}
