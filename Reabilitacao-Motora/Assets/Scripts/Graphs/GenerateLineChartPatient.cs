using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Descrever aqui o que essa classe realiza.
*/
public class GenerateLineChartPatient : MonoBehaviour
{
	[SerializeField]
	protected Transform pointPrefab, mao, ombro, cotovelo, braco;

	List <float> current_time;
	List <Vector3> p_mao_pos, p_mao_rot, p_ombro_pos, p_ombro_rot, p_cotovelo_pos, p_cotovelo_rot, p_braco_pos, p_braco_rot, points2;

	LineRenderer lineRenderer;

	private static readonly Color c1 = Color.black;
	private static readonly Color c2 = Color.blue;

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
			p_mao_pos.Add(new Vector3 (a, b, c));
			a = (float.Parse(pair[4]));
			b = (float.Parse(pair[5]));
			c = (float.Parse(pair[6]));
			p_mao_rot.Add(new Vector3 (a, b, c));

			a = (float.Parse(pair[7]));
			b = (float.Parse(pair[8]));
			c = (float.Parse(pair[9]));
			p_cotovelo_pos.Add(new Vector3 (a, b, c));
			a = (float.Parse(pair[10]));
			b = (float.Parse(pair[11]));
			c = (float.Parse(pair[12]));
			p_cotovelo_rot.Add(new Vector3 (a, b, c));

			a = (float.Parse(pair[13]));
			b = (float.Parse(pair[14]));
			c = (float.Parse(pair[15]));
			p_ombro_pos.Add(new Vector3 (a, b, c));
			a = (float.Parse(pair[16]));
			b = (float.Parse(pair[17]));
			c = (float.Parse(pair[18]));
			p_ombro_rot.Add(new Vector3 (a, b, c));

			a = (float.Parse(pair[19]));
			b = (float.Parse(pair[20]));
			c = (float.Parse(pair[21]));
			p_braco_pos.Add(new Vector3 (a, b, c));
			a = (float.Parse(pair[22]));
			b = (float.Parse(pair[23]));
			c = (float.Parse(pair[24]));
			p_braco_rot.Add(new Vector3 (a, b, c));					
		}
	}


	/**
	* Descrever aqui o que esse método realiza.
	*/
	public void Awake()
	{
		if(GlobalController.instance != null && 
		   GlobalController.instance.movement != null)
		{
			t = false;
			drawed = false;

			current_time = new List<float>();
			p_mao_pos = new List<Vector3>();
			p_mao_rot = new List<Vector3>();
			p_ombro_pos = new List<Vector3>();
			p_ombro_rot = new List<Vector3>();
			p_cotovelo_pos = new List<Vector3>();
			p_cotovelo_rot = new List<Vector3>();
			p_braco_pos = new List<Vector3>();
			p_braco_rot = new List<Vector3>();

			points2 = new List<Vector3>();

			string[] p1 = System.IO.File.ReadAllLines(string.Format("Assets/Exercicios/{0}", GlobalController.instance.exercise.pontosExercicio));
			LoadData (p1);
			
			LoadLineRenderer();
		}
		else
		{
			Debug.Log("Você violou o acesso!");	
		}
		
	}

	/**
	* Descrever aqui o que esse método realiza.
	*/
	public void Update () 
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
			ombro.localPosition = p_ombro_pos[i];
			ombro.localEulerAngles = p_ombro_rot[i];

			braco.localPosition = p_braco_pos[i];
			braco.localEulerAngles = p_braco_rot[i];

			cotovelo.localPosition = p_cotovelo_pos[i];
			cotovelo.localEulerAngles = p_cotovelo_rot[i];

			mao.localPosition = p_mao_pos[i];
			mao.localEulerAngles = p_mao_rot[i];

			yield return new WaitForSeconds(0.02f);        
		} 
	}

	public IEnumerator drawGraphic ()
	{
		float step = 2f / 70;
		Vector3 scale = Vector3.one * step;
		Vector3 position = Vector3.zero;
		Vector2 m_p, c_p, o_p, grafico;

		for (int j = 0; j < current_time.Count; ++j) 
		{
			m_p = new Vector2 (mao.position.x, mao.position.y);
			c_p = new Vector2 (cotovelo.position.x, cotovelo.position.y);
			o_p = new Vector2 (ombro.position.x, ombro.position.y);
			grafico = new Vector2 (current_time[j], _Joint.Angle(m_p, c_p, c_p, o_p));

			Transform point = Instantiate(pointPrefab);
			position.x = (grafico.x) + 0.05f;
			position.y = (grafico.y/24);
			position.z = 0.0f;
			point.localPosition = position;
			point.localScale = scale;
			point.SetParent (transform, false);
			points2.Add (point.localPosition);

			lineRenderer.SetVertexCount(points2.Count); 
			lineRenderer.SetPosition(points2.Count-1, point.localPosition);
			
			yield return new WaitForSeconds(0.02f);
		}
	}

	public void LoadLineRenderer ()
	{
		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Particles/Multiply (Double)"));
		lineRenderer.widthMultiplier = 0.2f;
		lineRenderer.positionCount = 4000;
		lineRenderer.sortingOrder = 5;
		lineRenderer.SetVertexCount(2);

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
		lineRenderer.useWorldSpace = false;
		lineRenderer.alignment = LineAlignment.Local;
	}
}
