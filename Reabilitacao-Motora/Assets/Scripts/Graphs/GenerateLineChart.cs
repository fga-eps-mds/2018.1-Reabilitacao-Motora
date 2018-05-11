using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Descrever aqui o que essa classe realiza.
*/
public class GenerateLineChart : MonoBehaviour
{
	[SerializeField]
	protected Transform pointPrefab, mao, ombro, cotovelo, braco;

	List <float> current_time;
	List <Vector3> f_mao_pos, f_mao_rot, f_ombro_pos, f_ombro_rot, f_cotovelo_pos, f_cotovelo_rot, f_braco_pos, f_braco_rot, points1, points2;

	LineRenderer lineRenderer;

	private static readonly Color c1 = Color.black;
	private static readonly Color c2 = Color.red;

	bool t;
	bool drawed;

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
		}
	}


	void generateGraphicPoints ()
	{
		for (int j = 0; j < current_time.Count; ++j) 
		{
			Vector3 temp = new Vector3 (current_time[j], 
										_Joint.Angle((Vector2)f_mao_pos[j],
													(Vector2)f_cotovelo_pos[j],
													(Vector2)f_cotovelo_pos[j],
													(Vector2)f_ombro_pos[j]), 
										0f);
			points1.Add (temp);
		}
	}


	/**
	* Descrever aqui o que esse método realiza.
	*/
	void Awake()
	{
		if(GlobalController.instance != null && 
		   GlobalController.instance.movement != null)
		{
			t = false;
			drawed = false;

			current_time = new List<float>();
			f_mao_pos = new List<Vector3>();
			f_mao_rot = new List<Vector3>();
			f_ombro_pos = new List<Vector3>();
			f_ombro_rot = new List<Vector3>();
			f_cotovelo_pos = new List<Vector3>();
			f_cotovelo_rot = new List<Vector3>();
			f_braco_pos = new List<Vector3>();
			f_braco_rot = new List<Vector3>();

			points1 = new List<Vector3>();
			points2 = new List<Vector3>();

			string[] p1 = System.IO.File.ReadAllLines(string.Format("Assets/Movimentos/{0}.points", GlobalController.instance.movement.pontosMovimento));
			LoadData (p1);
			
			lineRenderer = gameObject.AddComponent<LineRenderer>();
			lineRenderer.material = new Material(Shader.Find("Particles/Multiply (Double)"));
			lineRenderer.widthMultiplier = 0.2f;
			lineRenderer.positionCount = p1.Length;

		// A simple 2 color gradient with a fixed alpha of 1.0f.
			float alpha = 1.0f;
			Gradient gradient = new Gradient();
			gradient.SetKeys(
				new []
				{
					new GradientColorKey(c1, 0.0f), 
					new GradientColorKey(c2, 1.0f) 
				},
				new [] 
				{
					new GradientAlphaKey(alpha, 0.0f), 
					new GradientAlphaKey(alpha, 1.0f) 
				}
			);
			lineRenderer.colorGradient = gradient;

			generateGraphicPoints();
		}
		else
		{
			Debug.Log("Você violou o acesso!");	
		}
		
	}

	/**
	* Descrever aqui o que esse método realiza.
	*/
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			t = !t;
			if (t == true && drawed == false) 
			{
				StartCoroutine("drawGraphic");
				StartCoroutine("Playback");
				drawed = true;
			}
		}
	}

	public IEnumerator Playback ()
	{  
		for (int i = 0; i < current_time.Count; i++) 
		{	
			ombro.localPosition = f_ombro_pos[i];
			ombro.localEulerAngles = f_ombro_rot[i];

			braco.localPosition = f_braco_pos[i];
			braco.localEulerAngles = f_braco_rot[i];

			cotovelo.localPosition = f_cotovelo_pos[i];
			cotovelo.localEulerAngles = f_cotovelo_rot[i];

			mao.localPosition = f_mao_pos[i];
			mao.localEulerAngles = f_mao_rot[i];

			yield return new WaitForSeconds(0.02f);        
		} 
	}

	public IEnumerator drawGraphic ()
	{
		float step = 2f / 70;
		Vector3 scale = Vector3.one * step;
		Vector3 position = Vector3.zero;

		for (int j = 0; j < current_time.Count; ++j) 
		{
			Transform point = Instantiate(pointPrefab);
			position.x = (points1[j].x) + 0.05f;
			position.y = (points1[j].y/24);
			point.localPosition = position;
			point.localScale = scale;
			point.SetParent (transform, false);
			points2.Add (point.position);
			lineRenderer.SetPositions (points2.ToArray());

			yield return new WaitForSeconds(0.02f);
		}

	}
}
