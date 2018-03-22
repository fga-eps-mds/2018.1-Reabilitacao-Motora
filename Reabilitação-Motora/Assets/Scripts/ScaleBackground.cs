using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Escala o tamanho dos componentes da scene conforme o tamanho da tela.
 */
public class ScaleBackground : MonoBehaviour 
{
	public float A;
	public float B;
	public float screenWidth;
	public float screenHeight;

	/**
     * Inicia as váriaves A e B com altura e comprimento da tela.
     */
	void Start() 
	{
		A = transform.localScale.x;
		B = transform.localScale.y;
	}

	/**
     * Atualiza o valor de altura e largura da tela em tempo real.
     */
	void Update() 
	{
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		transform.localScale = new Vector3((A * screenWidth / screenHeight), transform.localScale.y, transform.localScale.z);
	}
}
