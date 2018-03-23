using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Escala o tamanho dos componentes da scene conforme o tamanho da tela.
 */
public class ScaleBackground : MonoBehaviour 
	{
	public float width;
	public float height;
	public float screenWidth;
	public float screenHeight;
	private float xAxis;

	/**
     * Inicia as váriaves width e height com altura e comprimento da tela.
     */
	void Start() 
	{
		width = transform.localScale.x;
		height = transform.localScale.y;
	}

	/**
     * Atualiza o valor de altura e largura da tela em tempo real.
     */
	void Update() 
	{
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		xAxis = (width * screenWidth / screenHeight);
		transform.localScale = new Vector3(xAxis, transform.localScale.y, transform.localScale.z);
	}
}
