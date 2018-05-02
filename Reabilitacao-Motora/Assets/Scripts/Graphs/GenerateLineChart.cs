using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Descrever aqui o que essa classe realiza.
*/
public class GenerateLineChart : MonoBehaviour
{
	public Transform pointPrefab;
	public Transform mao, ombro, cotovelo, braco;
	public int resolution;
	int i = 0;
	List <float> current_time;
	List <Vector3> f_mao_pos, f_mao_rot, f_ombro_pos, f_ombro_rot, f_cotovelo_pos, f_cotovelo_rot, f_braco_pos, f_braco_rot, points1, points2;
	List <Vector3> f_mao_local_pos, f_mao_local_rot, f_ombro_local_pos, f_ombro_local_rot, f_cotovelo_local_pos, f_cotovelo_local_rot, f_braco_local_pos, f_braco_local_rot;

	LineRenderer lineRenderer;
	public Color c1 = Color.black;
	public Color c2 = Color.red;

	bool t = false, drawed = false;

	/**
	* Descrever aqui o que esse método realiza.
	*/
	public void LoadData(string[] lines)
	{
		foreach (var line in lines)
		{
			var pair = line.Split(' ');
			float x = (float.Parse(pair[0]));
			current_time.Add(x);

			float a = (float.Parse(pair[1]));
			float b = (float.Parse(pair[2]));
			float c = (float.Parse(pair[3]));
			f_mao_pos.Add(new Vector3 (a, b, c));
			
			a = (float.Parse(pair[4]));
			b = (float.Parse(pair[5]));
			c = (float.Parse(pair[6]));
			f_mao_rot.Add(new Vector3 (a, b, c));

			a = (float.Parse(pair[7]));
			b = (float.Parse(pair[8]));
			c = (float.Parse(pair[9]));
			f_cotovelo_pos.Add(new Vector3 (a, b, c));

			a = (float.Parse(pair[10]));
			b = (float.Parse(pair[11]));
			c = (float.Parse(pair[12]));
			f_cotovelo_rot.Add(new Vector3 (a, b, c));

			a = (float.Parse(pair[13]));
			b = (float.Parse(pair[14]));
			c = (float.Parse(pair[15]));
			f_ombro_pos.Add(new Vector3 (a, b, c));

			a = (float.Parse(pair[16]));
			b = (float.Parse(pair[17]));
			c = (float.Parse(pair[18]));
			f_ombro_rot.Add(new Vector3 (a, b, c));

			a = (float.Parse(pair[19]));
			b = (float.Parse(pair[20]));
			c = (float.Parse(pair[21]));
			f_braco_pos.Add(new Vector3 (a, b, c));

			a = (float.Parse(pair[22]));
			b = (float.Parse(pair[23]));
			c = (float.Parse(pair[24]));
			f_braco_rot.Add(new Vector3 (a, b, c));			

 //____________________________________________________

			a = (float.Parse(pair[25]));
			b = (float.Parse(pair[26]));
			c = (float.Parse(pair[27]));
			f_mao_local_pos.Add(new Vector3 (a, b, c));
			
			a = (float.Parse(pair[28]));
			b = (float.Parse(pair[29]));
			c = (float.Parse(pair[30]));
			f_mao_local_rot.Add(new Vector3 (a, b, c));

			a = (float.Parse(pair[31]));
			b = (float.Parse(pair[32]));
			c = (float.Parse(pair[33]));
			f_cotovelo_local_pos.Add(new Vector3 (a, b, c));

			a = (float.Parse(pair[34]));
			b = (float.Parse(pair[35]));
			c = (float.Parse(pair[36]));
			f_cotovelo_local_rot.Add(new Vector3 (a, b, c));

			a = (float.Parse(pair[37]));
			b = (float.Parse(pair[38]));
			c = (float.Parse(pair[39]));
			f_ombro_local_pos.Add(new Vector3 (a, b, c));

			a = (float.Parse(pair[40]));
			b = (float.Parse(pair[41]));
			c = (float.Parse(pair[42]));
			f_ombro_local_rot.Add(new Vector3 (a, b, c));

			a = (float.Parse(pair[43]));
			b = (float.Parse(pair[44]));
			c = (float.Parse(pair[45]));
			f_braco_local_pos.Add(new Vector3 (a, b, c));

			a = (float.Parse(pair[46]));
			b = (float.Parse(pair[47]));
			c = (float.Parse(pair[48]));
			f_braco_local_rot.Add(new Vector3 (a, b, c));			
		}
	}

	public static float hypot(float a, float b)
	{
		return Mathf.Sqrt(Mathf.Pow(a, 2) + Mathf.Pow(b, 2));
	}

	float angle(Vector2 P, Vector2 Q, Vector2 R, Vector2 S)
	{
		float ux = P.x - Q.x;
		float uy = P.y - Q.y;

		float vx = R.x - S.x;
		float vy = R.y - S.y;

		float num = ux * vx + uy * vy;
		float den = hypot(ux, uy) * hypot(vx, vy);

		return (Mathf.Acos(num / den) * (180.0f / Mathf.PI));
	}

	void generateGraphicPoints ()
	{
		for (int i = 0; i < current_time.Count; ++i) {
			Vector3 temp = new Vector3 (current_time[i], angle((Vector2)f_mao_pos[i],(Vector2)f_cotovelo_pos[i],(Vector2)f_cotovelo_pos[i],(Vector2)f_ombro_pos[i]), 0f);
			points1.Add (temp);
		}
	}

	void drawGraphic ()
	{
		float step = 2f / 70;
		Vector3 scale = Vector3.one * step;
		Vector3 position = Vector3.zero;

		for (int i = 0; i < resolution; ++i) 
		{
			Transform point = Instantiate(pointPrefab);
			position.x = (points1[i].x) + 0.05f;
			position.y = (points1[i].y/24);
			point.localPosition = position;
			point.localScale = scale;
			point.SetParent (transform, false);

			points2.Add (point.position);
		}

		lineRenderer.SetPositions (points2.ToArray());
	}

	/**
	* Descrever aqui o que esse método realiza.
	*/
	void Awake()
	{

		if(GlobalController.instance != null && 
		   GlobalController.instance.movement != null){

			current_time = new List<float>();
			f_mao_pos = new List<Vector3>();
			f_mao_rot = new List<Vector3>();
			f_ombro_pos = new List<Vector3>();
			f_ombro_rot = new List<Vector3>();
			f_cotovelo_pos = new List<Vector3>();
			f_cotovelo_rot = new List<Vector3>();
			f_braco_pos = new List<Vector3>();
			f_braco_rot = new List<Vector3>();

			f_mao_local_pos = new List<Vector3>();
			f_mao_local_rot = new List<Vector3>();
			f_ombro_local_pos = new List<Vector3>();
			f_ombro_local_rot = new List<Vector3>();
			f_cotovelo_local_pos = new List<Vector3>();
			f_cotovelo_local_rot = new List<Vector3>();
			f_braco_local_pos = new List<Vector3>();
			f_braco_local_rot = new List<Vector3>();

			points1 = new List<Vector3>();
			points2 = new List<Vector3>();

			string[] p1 = System.IO.File.ReadAllLines(string.Format("Assets/Movimentos/{0}.points", GlobalController.instance.movement.pontosMovimento));
			LoadData (p1);
			
			lineRenderer = gameObject.AddComponent<LineRenderer>();
			lineRenderer.material = new Material(Shader.Find("Particles/Multiply (Double)"));
			lineRenderer.widthMultiplier = 0.2f;
			lineRenderer.positionCount = p1.Length;
			resolution = p1.Length;

		// A simple 2 color gradient with a fixed alpha of 1.0f.
			float alpha = 1.0f;
			Gradient gradient = new Gradient();
			gradient.SetKeys(
			new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
			new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
			);
			lineRenderer.colorGradient = gradient;

			generateGraphicPoints();
		}
		else{
			Debug.Log("Você violou o acesso!");	
		}
		
	}

	/**
	* Descrever aqui o que esse método realiza.
	*/
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space)) {
			t = !t;
			if (t == true && drawed == false) {
				drawGraphic();
				drawed = true;
			}
		}
	}

	void FixedUpdate ()
	{
		if (t && i < current_time.Count) 
		{
			ombro.SetPositionAndRotation(f_ombro_pos[i], Quaternion.Euler(f_ombro_rot[i]));
			braco.SetPositionAndRotation(f_braco_pos[i], Quaternion.Euler(f_braco_rot[i]));
			cotovelo.SetPositionAndRotation(f_cotovelo_pos[i], Quaternion.Euler(f_cotovelo_rot[i]));
			mao.SetPositionAndRotation(f_mao_pos[i], Quaternion.Euler(f_mao_rot[i]));

			i++;
		}
	}
}
