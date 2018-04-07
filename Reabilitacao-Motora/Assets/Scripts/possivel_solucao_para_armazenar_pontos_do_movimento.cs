using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class possivel_solucao_para_armazenar_pontos_do_movimento : MonoBehaviour {

	public static float hypot(float a, float b)
	{
		return Mathf.Sqrt(Mathf.Pow(a, 2) + Mathf.Pow(b, 2));
	}

	public class Point {
		public float x;
		public float y;

		public Point (float xv = 0, float yv = 0) {this.x = xv; this.y = yv;}
	}


	float angle(Point P, Point Q, Point R, Point S)
	{
		float ux = P.x - Q.x;
		float uy = P.y - Q.y;

		float vx = R.x - S.x;
		float vy = R.y - S.y;

		float num = ux * vx + uy * vy;
		float den = hypot(ux, uy) * hypot(vx, vy);

		return Mathf.Acos(num / den);
	}

	public GameObject mao, cotovelo, ombro; //o ponto final de mao é o inicial de cotovelo, o final de cotovelo é o inicial de ombro; ou seja, sao apenas 2 retas
	List<Point> tempo_anguloDeJunta;
	Point m_p, c_p, o_p, grafico;
	float current_time_movement = 0;

	void Start () {
		tempo_anguloDeJunta = new List<Point> ();
	}
	
	void FixedUpdate () {
		current_time_movement += Time.fixedDeltaTime;
		m_p = new Point (mao.transform.position.x, mao.transform.position.y);
		c_p = new Point (cotovelo.transform.position.x, cotovelo.transform.position.y);
		o_p = new Point (ombro.transform.position.x, ombro.transform.position.y);

		grafico = new Point (current_time_movement, angle (m_p, c_p, c_p, o_p));
		tempo_anguloDeJunta.Add (grafico);
	}
}
