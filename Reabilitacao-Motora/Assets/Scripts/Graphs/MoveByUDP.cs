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

	Vector3 f_mao_pos, f_mao_rot, f_ombro_pos, f_ombro_rot, f_cotovelo_pos, f_cotovelo_rot, f_braco_pos, f_braco_rot;
	float current_time_movement;
	LineRenderer lineRenderer;
	bool t;

	private static readonly Color c1 = Color.black;
	private static readonly Color c2 = Color.red;
	private static readonly Color c3 = Color.blue;

    UdpClient client;
    public int receivePort = 5004;
    IPAddress groupIP = IPAddress.Parse("127.0.0.1");
    IPEndPoint remoteEP;   

    string rxString;


    void Start () 
    {
        Debug.Log("Starting Client");
        remoteEP = new IPEndPoint(IPAddress.Any, receivePort);

        client = new UdpClient(remoteEP);
        client.JoinMulticastGroup(groupIP);

        client.BeginReceive(new AsyncCallback(ReceiveServerInfo), null);
    	StartCoroutine("Waiter");
    }

    public IEnumerator Waiter()
    {
    	yield return new WaitForSeconds(0.8f);
    	ombro = GameObject.Find("mixamorig:LeftShoulder").transform;
    	braco = GameObject.Find("mixamorig:LeftArm").transform;
    	cotovelo = GameObject.Find("mixamorig:LeftForeArm").transform;
    	mao = GameObject.Find("mixamorig:LeftHand").transform;
    }

    void ReceiveServerInfo (IAsyncResult result) 
    {        
        //Debug.Log("Received Server Info");
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
	
	/**
	* Descrever aqui o que esse método realiza.
	*/
	void Awake()
	{
		if(GlobalController.instance != null && 
		   (GlobalController.instance.movement != null ||
		   	GlobalController.instance.exercise != null)
		  )
		{
			t = false;
			var go = gameObject;
			current_time_movement = 0;
			if (GlobalController.patientOrPhysio)
			{
				GetMovementPoints.LoadLineRenderer(ref go, ref lineRenderer, c1, c2);
			}
			else
			{
				GetMovementPoints.LoadLineRenderer(ref go, ref lineRenderer, c1, c3);
			}
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

			current_time_movement += Time.fixedDeltaTime;

			ombro.localPosition = f_ombro_pos;
			ombro.localEulerAngles = f_ombro_rot;

			braco.localPosition = f_braco_pos;
			braco.localEulerAngles = f_braco_rot;

			cotovelo.localPosition = f_cotovelo_pos;
			cotovelo.localEulerAngles = f_cotovelo_rot;

			mao.localPosition = f_mao_pos;
			mao.localEulerAngles = f_mao_rot;

			if (GlobalController.patientOrPhysio)
			{
				GetMovementPoints.SavePoints (current_time_movement,
					"/Movimentos/", 
					GlobalController.instance.movement.pontosMovimento,
					mao, 
					cotovelo,
					ombro, 
					braco);
			}
			else
			{
				GetMovementPoints.SavePoints (current_time_movement,
					"/Exercicios/", 
					GlobalController.instance.exercise.pontosExercicio,
					mao, 
					cotovelo,
					ombro, 
					braco);
			}	

			GetMovementPoints.graphSpawner(transform, pointPrefab, mao, cotovelo, ombro, current_time_movement, ref lineRenderer); 
			if (current_time_movement > 15)
			{
				t = false;
			}
		}
	}
}