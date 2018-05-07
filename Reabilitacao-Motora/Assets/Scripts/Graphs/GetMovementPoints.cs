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
	public Transform mao, cotovelo, ombro, braco; //o ponto final de mao é o inicial de cotovelo, o final de cotovelo é o inicial de ombro; ou seja, sao apenas 2 retas
//	List<Vector2> tempo_anguloDeJunta;
	float current_time_movement = 0;
	bool t = false;

	/**
	 * Descrever aqui o que esse método realiza.
	 */
	void Start () {
		//tempo_anguloDeJunta = new List<Vector2> ();
	}

	/**
	 * Descrever aqui o que esse método realiza.
	 */
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			t = !t;
		}
	}


	/**
	 * Descrever aqui o que esse método realiza.
	 */
	void FixedUpdate () 
	{
		if (t) 
		{
			current_time_movement += Time.fixedDeltaTime;
			
			StringBuilder sb = new StringBuilder();

			sb.Append(current_time_movement).Append(" ");

			sb.Append(mao.position.x).Append(" ").Append(mao.position.y).Append(" ").Append(mao.position.z).Append(" ");
			sb.Append(mao.rotation.x).Append(" ").Append(mao.rotation.y).Append(" ").Append(mao.rotation.z).Append(" ");

			sb.Append(cotovelo.position.x).Append(" ").Append(cotovelo.position.y).Append(" ").Append(cotovelo.position.z).Append(" ");
			sb.Append(cotovelo.rotation.x).Append(" ").Append(cotovelo.rotation.y).Append(" ").Append(cotovelo.rotation.z).Append(" ");

			sb.Append(ombro.position.x).Append(" ").Append(ombro.position.y).Append(" ").Append(ombro.position.z).Append(" ");
			sb.Append(ombro.rotation.x).Append(" ").Append(ombro.rotation.y).Append(" ").Append(ombro.rotation.z).Append(" ");

			sb.Append(braco.position.x).Append(" ").Append(braco.position.y).Append(" ").Append(braco.position.z).Append(" ");
			sb.Append(braco.rotation.x).Append(" ").Append(braco.rotation.y).Append(" ").Append(braco.rotation.z).Append("\n");

			string path = Application.dataPath + "/Movimentos/" + GlobalController.instance.movement.pontosMovimento + ".points";
			File.AppendAllText(path, sb.ToString());
		}
	}
}
