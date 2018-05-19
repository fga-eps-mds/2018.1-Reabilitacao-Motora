using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

/**
 * Descrever aqui o que essa classe realiza.
 */
public class GetMovementPoints : MonoBehaviour
{
	[SerializeField]
	protected Transform mao, cotovelo, ombro, braco; //o ponto final de mao é o inicial de cotovelo, o final de cotovelo é o inicial de ombro; ou seja, sao apenas 2 retas
	
	float current_time_movement;
	bool t;

	/**
	 * Descrever aqui o que esse método realiza.
	 */
	public void ActivateCaption () 
	{
		t = true;
	}

	/**
	 * Descrever aqui o que esse método realiza.
	 */
	public void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			t = !t;
		}
	}

	public void Awake ()
	{
		current_time_movement = 0;
		t = false;
	}
	
	/**
	 * Descrever aqui o que esse método realiza.
	 */
	public void FixedUpdate () 
	{
		if (t) 
		{
			current_time_movement += Time.fixedDeltaTime;
			
			StringBuilder sb = new StringBuilder();
			sb.Append(current_time_movement).Append(" ");

			sb.Append(mao.localPosition.x).Append(" ").Append(mao.localPosition.y).Append(" ").Append(mao.localPosition.z).Append(" ");
			sb.Append(mao.localEulerAngles.x).Append(" ").Append(mao.localEulerAngles.y).Append(" ").Append(mao.localEulerAngles.z).Append(" ");

			sb.Append(cotovelo.localPosition.x).Append(" ").Append(cotovelo.localPosition.y).Append(" ").Append(cotovelo.localPosition.z).Append(" ");
			sb.Append(cotovelo.localEulerAngles.x).Append(" ").Append(cotovelo.localEulerAngles.y).Append(" ").Append(cotovelo.localEulerAngles.z).Append(" ");

			sb.Append(ombro.localPosition.x).Append(" ").Append(ombro.localPosition.y).Append(" ").Append(ombro.localPosition.z).Append(" ");
			sb.Append(ombro.localEulerAngles.x).Append(" ").Append(ombro.localEulerAngles.y).Append(" ").Append(ombro.localEulerAngles.z).Append(" ");

			sb.Append(braco.localPosition.x).Append(" ").Append(braco.localPosition.y).Append(" ").Append(braco.localPosition.z).Append(" ");
			sb.Append(braco.localEulerAngles.x).Append(" ").Append(braco.localEulerAngles.y).Append(" ").Append(braco.localEulerAngles.z).Append("\n");

			string path = Application.dataPath + "/Movimentos/" + GlobalController.instance.movement.pontosMovimento + ".points";
			File.AppendAllText(path, sb.ToString());
		}
	}
}
