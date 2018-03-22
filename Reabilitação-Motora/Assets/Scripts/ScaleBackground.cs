using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBackground : MonoBehaviour {

	/**
     * Uma variável pública.
     * Salva o tamanho horizontal da tela.
     */
	public float A;

	/**
     * Uma variável pública.
     * Salva o tamanho vertical da tela.
     */
	public float B;

	/**
     * Uma variável pública.
     * Comprimento da tela.
     */
	public float screenWidth;

	/**
     * Uma variável pública.
     * Altura da tela.
     */
	public float screenHeight;

	/**
     * Inicia as váriaves A e B com altura e comprimento da tela.
     */
	void Start () {
		A = transform.localScale.x;
		B = transform.localScale.y;
	}

	/**
     * Atualiza o valor de altura e largura da tela em tempo real.
     */
	void Update () {
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		transform.localScale = new Vector3 ((A * screenWidth / screenHeight), transform.localScale.y, transform.localScale.z);
	}
}
