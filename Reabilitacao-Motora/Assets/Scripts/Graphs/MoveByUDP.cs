using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Text;
using System;
using System.Net;
using System.Threading;

/**
* Descrever aqui o que essa classe realiza.
*/
public class MoveByUDP : MonoBehaviour
{
	[SerializeField]
	protected Transform pointPrefab, mao, ombro, cotovelo, braco;

	float current_time;
	Vector3 f_mao_pos, f_mao_rot, f_ombro_pos, f_ombro_rot, f_cotovelo_pos, f_cotovelo_rot, f_braco_pos, f_braco_rot;
	List <Vector3> points2;

	LineRenderer lineRenderer;

	private static readonly Color c1 = Color.black;
	private static readonly Color c2 = Color.red;

	bool t;
	bool drawed;

    UdpClient client;
    public int receivePort = 5004;
    IPAddress groupIP = IPAddress.Parse("127.0.0.1");
    IPEndPoint remoteEP;   

    string rxString;


    void Start () {
        Debug.Log("Starting Client");
        remoteEP = new IPEndPoint(IPAddress.Any, receivePort);

        client = new UdpClient(remoteEP);
        client.JoinMulticastGroup(groupIP);

        client.BeginReceive(new AsyncCallback(ReceiveServerInfo), null);
    }

    void ReceiveServerInfo (IAsyncResult result) {        
        Debug.Log("Received Server Info");
        byte[] receivedBytes = client.EndReceive(result, ref remoteEP);

        rxString = System.Text.Encoding.UTF8.GetString(receivedBytes);
        LoadData(rxString);
    }

	/**
	* Descrever aqui o que esse método realiza.
	*/
	public void LoadData(string line)
	{
		var pair = line.Split(' ');
		float x = (float.Parse(pair[0]));
		current_time = (x);

		float a = (float.Parse(pair[1]));
		float b = (float.Parse(pair[2]));
		float c = (float.Parse(pair[3]));
		f_mao_pos = (new Vector3 (a, b, c));
		a = (float.Parse(pair[4]));
		b = (float.Parse(pair[5]));
		c = (float.Parse(pair[6]));
		f_mao_rot = (new Vector3 (a, b, c));

		a = (float.Parse(pair[7]));
		b = (float.Parse(pair[8]));
		c = (float.Parse(pair[9]));
		f_cotovelo_pos = (new Vector3 (a, b, c));
		a = (float.Parse(pair[10]));
		b = (float.Parse(pair[11]));
		c = (float.Parse(pair[12]));
		f_cotovelo_rot = (new Vector3 (a, b, c));

		a = (float.Parse(pair[13]));
		b = (float.Parse(pair[14]));
		c = (float.Parse(pair[15]));
		f_ombro_pos = (new Vector3 (a, b, c));
		a = (float.Parse(pair[16]));
		b = (float.Parse(pair[17]));
		c = (float.Parse(pair[18]));
		f_ombro_rot = (new Vector3 (a, b, c));

		a = (float.Parse(pair[19]));
		b = (float.Parse(pair[20]));
		c = (float.Parse(pair[21]));
		f_braco_pos = (new Vector3 (a, b, c));
		a = (float.Parse(pair[22]));
		b = (float.Parse(pair[23]));
		c = (float.Parse(pair[24]));
		f_braco_rot = (new Vector3 (a, b, c));					
	
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

			points2 = new List<Vector3>();
			
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
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			t = !t;
		}
	}

	public void FixedUpdate()
	{
		if (t){
			client.BeginReceive (new AsyncCallback (ReceiveServerInfo), null);
	        Playback();
		}
	}

	public void Playback ()
	{  
			
		ombro.localPosition = f_ombro_pos;
		ombro.localEulerAngles = f_ombro_rot;

		braco.localPosition = f_braco_pos;
		braco.localEulerAngles = f_braco_rot;

		cotovelo.localPosition = f_cotovelo_pos;
		cotovelo.localEulerAngles = f_cotovelo_rot;

		mao.localPosition = f_mao_pos;
		mao.localEulerAngles = f_mao_rot;
       
	 
	}
}