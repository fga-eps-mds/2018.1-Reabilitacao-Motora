using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graph : MonoBehaviour {

	public Transform pointPrefab;
	[Range(10, 750)]
	public int resolution = 10;
	List <Vector3> points1, points2;
	public float lineWidth = 0.05f;
	LineRenderer lineRenderer;
    public Color c1 = Color.yellow;
    public Color c2 = Color.red;


	public void LoadData(string[] lines)
    {
        foreach (var line in lines)
        {
            var pair = line.Split(' ');
            float x = (float.Parse(pair[0]));
            float y = (float.Parse(pair[1]));
            points1.Add(new Vector3 (x, y, 0f));
        }
    }


	// Use this for initialization
	void Awake () 
	{
		lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.widthMultiplier = 0.2f;
        lineRenderer.positionCount = 750;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
        lineRenderer.colorGradient = gradient;


		points1 = new List<Vector3>();
		points2 = new List<Vector3>();

		string[] p1 = System.IO.File.ReadAllLines("Assets/points.txt");
    	LoadData (p1);

		float step = 2f / 70;
		Vector3 scale = Vector3.one * step;
		Vector3 position = Vector3.zero;

		for (int i = 0; i < resolution; ++i) {
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
	
	// Update is called once per frame
	void Update () {

	}
}
