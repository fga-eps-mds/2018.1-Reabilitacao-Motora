using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Descrever aqui o que essa classe realiza. 
 */
public class Label : MonoBehaviour
{
	public TextMesh Description;
	[Range(0, 15)]
	public float InitialX = 0, FinalX = 0;
}
