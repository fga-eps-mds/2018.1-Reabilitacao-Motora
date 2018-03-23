using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Escala o tamanho dos componentes da scene conforme o tamanho da tela.
 */
public class ScaleBackground : MonoBehaviour 
	{
	public float objectLocalScaleX;
	public float objectLocalScaleY;
	public float screenWidth;
	public float screenHeight;
	private float xAxis;

	/**
     * Inicia as váriaves objectLocalScaleX e objectLocalScaleY com altura e comprimento da tela.
     */
	void Start() 
	{
		objectLocalScaleX = transform.localScale.x;
		objectLocalScaleY = transform.localScale.y;
	}

	/**
     * Atualiza o valor de altura e largura da tela em tempo real.
     */
	void Update() 
	{
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		xAxis = (objectLocalScaleX * screenWidth / screenHeight);
		transform.localScale = new Vector3(xAxis, transform.localScale.y, transform.localScale.z);
	}
}
