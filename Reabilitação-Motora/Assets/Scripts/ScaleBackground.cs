using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBackground : MonoBehaviour {
	public float A;
	public float B;
	public float screenwidth;
	public float screenheight;

	// Use this for initialization
	void Start () {
		A = transform.localScale.x;
		B = transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
		screenwidth = Screen.width;
		screenheight = Screen.height;
		transform.localScale = new Vector3 ((A * screenwidth / screenheight), transform.localScale.y, transform.localScale.z);
	}
}
